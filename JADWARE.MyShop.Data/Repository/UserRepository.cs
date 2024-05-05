using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Data.Helpers;
using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Requests.Users;
using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Xml.Linq;

namespace JADWARE.MyShop.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private string _connectionString;
        private string _keyString = Properties.Resources.secretKey;
        private string _ivString = Properties.Resources.ivString;
        private string _tableName = "USUARIOS";

        MailHelper mailHelper = new MailHelper();

        public UserRepository()
        {
            _connectionString = Properties.Resources.connectionString;
        }

        public async Task<User> GetUserByMailAndPasswordAsync(GetUserByMailAndPassRequest request, CancellationToken ct)
        {
            try
            {
                string email = request.Email;
                string password = request.Password;

                string passwordEncrypt = SecurityHelper.encryptData(password, _keyString, _ivString);

                string query = $"SELECT * FROM {_tableName} WHERE CORREO = @CORREO AND PASSWORD = @PASSWORD AND USUARIOID>0";
                var commandDefinition = new CommandDefinition(query, new { CORREO = email, PASSWORD = passwordEncrypt }, cancellationToken: ct);

                using var connection = new SqlConnection(_connectionString);
                var user = await connection.QueryFirstAsync<User>(commandDefinition);

                return user;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Boolean> SendPasswordByEmailAsync(SendPasswordToUserRequest request, CancellationToken ct)
        {
            try
            {
                string email = request.Email;

                string query = $"SELECT PASSWORD FROM {_tableName} WHERE CORREO = @CORREO AND USUARIOID>0";
                var commandDefinition = new CommandDefinition(query, new {CORREO=email}, cancellationToken: ct);

                using var connection = new SqlConnection(_connectionString);
                var passwordEncrypt = await connection.QueryFirstOrDefaultAsync<string>(commandDefinition);

                var passwordDecrypt = SecurityHelper.DecryptData(passwordEncrypt, _keyString, _ivString);

                var emailSubject = "Recuperacion de contraseña My Shop";
                var emailBody = $"Hemos recibido una solicitud para restablecer tu contraseña para tu cuenta en My Shop. La contraseña de tu cuenta es: {passwordDecrypt}";

                Boolean send = await mailHelper.SendMail(request.Email, emailSubject, emailBody);

                return send;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<Boolean> VerifyEmailExistsAsync(VerifyEmailExistsRequest request, CancellationToken ct)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {_tableName} WHERE CORREO = @CORREO AND USUARIOID>0";
                var commandDefinition = new CommandDefinition(query, new { CORREO = request.Email }, cancellationToken: ct);

                using var connection = new SqlConnection(_connectionString);
                var response = await connection.QueryFirstAsync<int>(commandDefinition);

                if(response < 1)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Boolean> InsertUserAsync(InsertUserRequest request, CancellationToken ct)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine($"INSERT INTO {_tableName} (CORREO, NOMBRE, TELEFONO, PAIS, ESTADO, CIUDAD, PASSWORD)");
                query.AppendLine($"VALUES (@EMAIL, @NAME, @PHONENUMBER, @COUNTRY, @STATE, @CITY, @PASSWORD)");

                var passwordEncrypted = SecurityHelper.encryptData(request.Password, _keyString, _ivString);

                var commandDefinition = new CommandDefinition(query.ToString(), new
                {
                    EMAIL = request.Email,
                    NAME = request.UserName,
                    PHONENUMBER = request.PhoneNumber,
                    COUNTRY = request.Country,
                    STATE = request.State,
                    CITY = request.City,
                    PASSWORD = passwordEncrypted
                }, cancellationToken: ct);

                using var connection = new SqlConnection(_connectionString);
                await connection.ExecuteAsync(commandDefinition);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
