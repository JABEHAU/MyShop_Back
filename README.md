# Proyecto My Shop - Back end
## Contenido
- [Equipo](#integrantes-del-equipo)
- [Objetivo](#objetivo-del-proyecto)
- [Requisitos funcionales](#requisitos-funcionales)
- [Diagramas de casos de uso](#diagramas-de-casos-de-uso)
- [Diagrama de despliegue](#diagrama-de-despliegue)
- [Enlaces](#enlaces)
<br>

## Integrantes del equipo
- **Jesus Alejandro Be Hau**
  - [![GitHub](https://img.shields.io/badge/GitHub-Jesus%20Be-red?style=flat&logo=github)](https://github.com/JABEHAU)
- **Juan Carlos Conde Marrufo**
  - [![GitHub](https://img.shields.io/badge/GitHub-Juan%20Conde-red?style=flat&logo=github)](https://github.com/JuanConde33)

## Objetivo del proyecto
Desarrollar una tienda en línea con la finalidad de ofrecer una experiencia de compra más cómoda y ágil para los usuarios. Este sistema permitirá a los usuarios la visualización de los productos que ofrecen los vendedores las 24 horas del día desde la comodidad de sus hogares, brindando un filtro de productos que se ajustarán mejor a las necesidades del usuario, al mismo tiempo que proporciona compras rápidas y seguras.
Los compradores podrán ver en tiempo real el seguimiento del producto enviado, con el objetivo de brindar transparencia en la relación entre clientes y vendedores.

## Requisitos funcionales

RF-01-Registro de usuarios [Prioridad alta]<br>
El sistema permitirá a los usuarios registrarse en el sistema mediante su correo electrónico, solicitándole además una contraseña y datos personales. 

RF-02-Gestión de cuenta de usuario [Prioridad alta]<br>
 El sistema permitirá al usuario modificar sus datos personales que ha registrado en el sistema. 

RF-03-Recuperación de contraseña [Prioridad alta]<br>
El sistema permitirá al usuario recuperar la contraseña de su cuenta enviándole la contraseña mediante su correo electrónico con el que se registró.

RF-04-Login [Prioridad alta]<br>
El sistema permitirá a los usuarios iniciar sesión en cualquier momento mediante su correo electrónico y contraseña. 

RF-05-Cuenta de vendedor [Prioridad baja]<br>
El sistema permitirá a los usuarios registrados en el sistema darse de alta como vendedores. 

RF-06-Visualización de productos [Prioridad alta]<br>
El usuario podrá visualizar todos los productos registrados en el sistema, independientemente de si el usuario se encuentra o no registrado. 

RF-07-Busqueda de productos [Prioridad alta]<br>
El sistema permitirá al usuario buscar algún producto mediante una barra de búsqueda, además de que existirán filtros para agilizar la búsqueda del usuario, como filtros por precio, por marca, género y categoría. 

RF-08-CRUD de productos en el carrito [Prioridad alta]<br>
El sistema permitirá al usuario agregar productos a su carrito, así como modificar la cantidad de piezas de los productos agregados, la visualización de su carrito en cualquier momento y la eliminación de productos que ha agregado.

RF-09-Compras [Prioridad alta]<br>
El sistema permitirá al usuario realizar la compra de productos existentes en el sistema, solicitando datos de pago (RF-10), así como datos del lugar de entrega del producto. 


RF-10-Validación de pagos [Prioridad alta]<br>
El sistema permitirá pagos a través de tarjetas de débito, por lo cual el sistema deberá validar que la transacción se haga correctamente. 

RF-11-Historial de compras [Prioridad alta]<br>
El sistema permitirá al usuario visualizar en cualquier momento su historial de compras realizadas, así como el estatus y detalles de cada una. 

RF-12-Calificación de productos [Prioridad alta]<br>
El sistema permitirá a los usuarios calificar los productos que han comprado, así como agregar algún comentario del producto que será visible públicamente.

RF-13-Alta de productos [Prioridad baja]<br>
El sistema permitirá a los usuarios dados de alta como vendedores, registrar nuevos productos a la venta en el sistema.

RF-14-Gestión de productos [Prioridad baja]<br>
El sistema permitirá a los vendedores modificar los datos o eliminar los productos que han dado de alta en el sistema (Cada vendedor podrá modificar únicamente el producto que el registro en el sistema). 

RF-15-Productos en oferta [Prioridad alta]<br>
El sistema permitirá a los vendedores marcar algún producto como oferta, solicitando el nuevo precio que se tomará como precio de oferta y será el que se muestre a los usuarios. 

RF-16-Historial de ventas [Prioridad baja]<br>
El sistema permitirá a los vendedores visualizar el historial de ventas que han realizado. 

RF-17-Estatus de ventas [Prioridad baja]<br>
El sistema permitirá a los vendedores cambiar el estatus de la venta que han realizado para dar seguimiento a la entrega del producto. 

RF-18-Notificación del cambio de estatus a compradores [Prioridad alta]<br>
El sistema deberá enviar una notificación por correo electrónico al usuario que ha realizado una compra, después de que el estatus de su compra sea modificado por el vendedor. 

RF-19-Costo de envío [Prioridad alta]<br>
El sistema deberá ser capaz de calcular el costo de envío de los productos según los factores que la empresa establezca, como la distancia del comprador y el vendedor y el monto de compra.
<br>
## Diagramas de casos de uso
![image](https://github.com/JABEHAU/MyShop_Front/assets/170541159/86a9fcf4-3513-40ff-ace0-816208a7abe5)
![image](https://github.com/JABEHAU/MyShop_Front/assets/170541159/1ac60619-17d7-4686-8abc-7522f4946d3d)

## Diagrama de despliegue
![image](https://github.com/JABEHAU/MyShop_Front/assets/170541159/36d0b63d-4d70-47b4-8ee7-84fee6757c80)

## Enlaces
- [Ejemplo de funcionamiento](https://www.youtube.com/watch?v=nGYaYwjjLRQ)
- [Repositorio del Front-end](https://github.com/JABEHAU/MyShop_Front)
- [Enlace del producto](https://myshoponline.azurewebsites.net)
