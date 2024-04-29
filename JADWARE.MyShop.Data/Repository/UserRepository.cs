using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Data.Helpers;
using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Requests.Users;
using System.Net.Mail;

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
                string email = request.email;

                string query = $"SELECT PASSWORD FROM {_tableName} WHERE CORREO = @CORREO AND USUARIOID>0";
                var commandDefinition = new CommandDefinition(query, new {CORREO=email}, cancellationToken: ct);

                using var connection = new SqlConnection(_connectionString);
                var passwordEncrypt = await connection.QueryFirstOrDefaultAsync<string>(commandDefinition);

                var passwordDecrypt = SecurityHelper.DecryptData(passwordEncrypt, _keyString, _ivString);

                var emailSubject = "Recuperacion de contraseña My Shop";
                var emailBody = $"Hemos recibido una solicitud para restablecer tu contraseña para tu cuenta en My Shop. La contraseña de tu cuenta es: {passwordDecrypt}";

                Boolean send = await mailHelper.SendMail(request.email, emailSubject, emailBody);

                return send;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
