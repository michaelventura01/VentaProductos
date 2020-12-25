create table ciudades(
    codigo VARCHAR(4) primary key,
    nombre VARCHAR(40) not null,
    pais VARCHAR(4) not null
);

create table paises(
    codigo VARCHAR(4) primary key,
    nombre VARCHAR(40) not null
);

create table tiendas(
    codigo VARCHAR(10) primary key,
    nombre VARCHAR(40) not null,
    direccion TEXT not null,
    ciudad VARCHAR(4) not null,
    estatus BIT not null
);

create table productos(
    codigo VARCHAR(10) primary key,
    nombre VARCHAR(40) not null,
);

create table productotiendas(
    codigo varchar(10) primary key,
    tienda VARCHAR(10) not null,
    producto VARCHAR(10) not null,
    estatus BIT not null,
    cantidad DECIMAL(10) not null,
    precio DECIMAL(10,2) not null,
);

create table usuarios(
    codigo VARCHAR(10) primary key,
    usuario VARCHAR(40) not null,
    clave VARCHAR(40) not null,
    tipoUsuario VARCHAR(2) not null,
    estatus BIT not null,
    tienda varchar(10) not null,
    nombre VARCHAR(40) not NULL,
    apellido VARCHAR(40) not null,
    correo text not null,
    ciudad varchar(4) not null
);

create table tipoUsuarios(
    codigo VARCHAR(2) primary key,
    descripcion VARCHAR(40) not null,
);

create table facturaEstatus(
    codigo VARCHAR(4) primary key,
    descripcion VARCHAR(40)
);

create table facturas(
    codigo VARCHAR(10) primary key,
    tiempoFacturacion datetime2 not null,
    estatus varchar(4) not null
)

create table pagoFacturas(
    codigo VARCHAR(10) primary key,
    tiempoPago datetime2 not null,
    factura  VARCHAR(10) not null,
    totalPago DECIMAL(10,2) not null
);

create table productosFacturas(
    codigo VARCHAR(10) primary key,
    producto VARCHAR(10) not null,
    factura  VARCHAR(10) not null,
    cantidad DECIMAL(10) not null,
    precio DECIMAL(10,2) not null,
    descuento DECIMAL(10,2) not null,
    impuesto DECIMAL(10,2) not null,
    estatus BIT not null
);

create table impuestosProductos(
    codigo VARCHAR(10) primary key,
    producto VARCHAR(10) not null,
    porcentage DECIMAL(10,2) not null,
    estatus BIT not null
);
create table descuentosProductos(
    codigo VARCHAR(10) primary key,
    producto VARCHAR(10) not null,
    porcentage DECIMAL(10,2) not null,
    estatus BIT not null
);

alter table ciudades 
add CONSTRAINT paisfk FOREIGN KEY(pais)
REFERENCES paises(codigo)
ON UPDATE CASCADE;

alter table tiendas
ADD CONSTRAINT ciudadfk FOREIGN KEY(ciudad)
REFERENCES ciudades(codigo)
ON UPDATE CASCADE;

alter table usuarios
ADD CONSTRAINT tipoUsuariofk FOREIGN KEY(tipoUsuario)
REFERENCES tipoUsuarios(codigo)
ON UPDATE CASCADE
ON DELETE CASCADE;

alter table pagoFacturas
ADD CONSTRAINT pagoFacturasfk FOREIGN KEY(factura)
REFERENCES facturas(codigo)
ON UPDATE CASCADE
ON DELETE CASCADE;

alter table productosFacturas
ADD CONSTRAINT productopagoFacturasfk FOREIGN KEY(producto)
REFERENCES productotiendas(codigo)
ON UPDATE CASCADE
ON DELETE CASCADE;

alter table productosFacturas
ADD CONSTRAINT facturapagoFacturasfk FOREIGN KEY(factura)
REFERENCES facturas(codigo)
ON UPDATE CASCADE
ON DELETE CASCADE;

alter table impuestosProductos
ADD CONSTRAINT impuestosProductosfk FOREIGN KEY(producto)
REFERENCES productos(codigo)
ON UPDATE CASCADE
ON DELETE CASCADE;

alter table descuentosProductos
ADD CONSTRAINT descuentosProductosfk FOREIGN KEY(producto)
REFERENCES productos(codigo)
ON UPDATE CASCADE
ON DELETE CASCADE;

alter table productotiendas
ADD CONSTRAINT productotiendasfk FOREIGN KEY(producto)
REFERENCES productos(codigo)
ON UPDATE CASCADE
ON DELETE CASCADE;

alter table productotiendas
ADD CONSTRAINT TIENDAproductotiendasfk FOREIGN KEY(tienda)
REFERENCES tiendas(codigo)
ON UPDATE CASCADE
ON DELETE CASCADE;


alter table usuarios
ADD CONSTRAINT TIENDAusuariofk FOREIGN KEY(tienda)
REFERENCES tiendas(codigo)
ON UPDATE CASCADE
ON DELETE CASCADE;

alter table usuarios
ADD CONSTRAINT ciudadusuariofk FOREIGN KEY(ciudad)
REFERENCES ciudades(codigo)

insert into paises(codigo, nombre) values ('RD', 'REPUBLICA DOMINICANA');
select * from ciudades;
alter table ciudades 

insert into ciudades(codigo, nombre, pais) values ('DN', 'DISTRITO NACIONAL', 'RD');
insert into ciudades(codigo, nombre, pais) values ('STO', 'SANTO DOMINGO OESTE', 'RD');
insert into ciudades(codigo, nombre, pais) values ('STE', 'SANTO DOMINGO ESTE', 'RD');
insert into ciudades(codigo, nombre, pais) values ('STG', 'SANTIAGO', 'RD');
insert into ciudades(codigo, nombre, pais) values ('VG', 'LA VEGA', 'RD');
insert into ciudades(codigo, nombre, pais) values ('SJM', 'SAN JUAN DE LA MAGUANA', 'RD');
insert into ciudades(codigo, nombre, pais) values ('SFM', 'SAN FRANCISCO DE MACORIS', 'RD');
insert into ciudades(codigo, nombre, pais) values ('SPM', 'SAN PEDRO DE MACORIS', 'RD');

insert into tiendas(codigo, nombre, direccion, ciudad, estatus) values ('t0000001', 'pescaderia la milagrosa', 'c/ antillano maruecos', 'DN', 1)

insert into productos(codigo, nombre) values ('p00000001', 'trituradora de escamas')
insert into productos(codigo, nombre) values ('p00000002', 'unidad de aire industrial');
insert into productos(codigo, nombre) values ('p00000003', 'motor de lancha g7');


insert into productotiendas(codigo, tienda, producto, estatus, cantidad, precio) values ('pt0000001', 't0000001', 'p00000001', 1, 5, 2500);
insert into productotiendas(codigo, tienda, producto, estatus, cantidad, precio) values ('pt0000002', 't0000001', 'p00000002', 1, 20, 4000);
insert into productotiendas(codigo, tienda, producto, estatus, cantidad, precio) values ('pt0000003', 't0000001', 'p00000003', 1, 50, 40000);

insert into tipoUsuarios(codigo, descripcion) values ('ad','administrador');
insert into tipoUsuarios(codigo, descripcion) values ('us','usuaario normal');

insert into usuarios(codigo, usuario, clave, tipoUsuario, estatus, tienda, nombre, apellido, correo, ciudad) 
values ('u0000001', 'mventura01', '123456', 'ad', 1, 't0000001', 'michael', 'ventura', 'micahel@mail.com', 'DN')


insert into facturaEstatus(codigo, descripcion)values('pg','pagado')
insert into facturaEstatus(codigo, descripcion)values('cr','credito')
insert into facturaEstatus(codigo, descripcion)values('prt','varios pagos')

insert into facturas(codigo, tiempoFacturacion, estatus) values ('f00000001','2020-12-20 22:10:11', 'pg' )

insert into pagoFacturas(codigo, tiempoPago, factura, total) values ('pg000001', '2020-12-20 22:10:11', 'f00000001', 5000)

insert into impuestosProductos(codigo, producto, porcentage, estatus) values ('ip000001', 'p00000001', 0.18, 1)
insert into impuestosProductos(codigo, producto, porcentage, estatus) values ('ip000002', 'p00000002', 0.18, 1)
insert into impuestosProductos(codigo, producto, porcentage, estatus) values ('ip000003', 'p00000003', 0.18, 1)

insert into descuentosProductos(codigo, producto, porcentage, estatus) values ('dp000003', 'p00000003', 0.08, 1)


insert into productosFacturas(codigo, producto, factura, cantidad, precio, descuento, impuesto, estatus)values('pf000001', 'pt0000001', 'f00000001', 2, 2500, 0, 0.18, 1)



create view verPaises as select * from paises;

select * from verPaises

create view ciudadesVer as select codigo, nombre, pais from ciudades



create procedure verCiudades @codigoPais varchar(4) AS
select codigo, nombre, pais from ciudadesVer where pais = @codigoPais

exec verCiudades @codigoPais = 'RD'

create view verTiendas as 
select 
    tienda.codigo, 
    tienda.nombre, 
    tienda.direccion, 
    ciudad.nombre as 'ciudad', 
    pais.nombre as 'pais', 
    CASE
        WHEN tienda.estatus = 1 THEN 'ACTIVO'
        WHEN tienda.estatus = 0 THEN 'INACTIVO'
    END as 'estatus',
    concat(usuario.nombre,' ',usuario.apellido) as 'titular',
    usuario.correo as 'correo_titular'
from tiendas as tienda
inner join ciudades as ciudad on tienda.ciudad = ciudad.codigo
inner join paises as pais on ciudad.pais = pais.codigo
inner join usuarios as usuario on tienda.codigo = usuario.tienda;


create view verProductosTiendas as 
select 
    producto.codigo as 'codigo_producto',
    tienda.codigo AS 'codigo_tienda',
    productotienda.codigo, 
    productotienda.cantidad, 
    productotienda.precio,
    tienda.nombre as 'tienda',
    tienda.direccion as 'direccion_tienda',
    tienda.ciudad,
    tienda.pais,
    producto.nombre,
    CASE
        WHEN productotienda.estatus = 1 THEN 'ACTIVO'
        WHEN productotienda.estatus = 0 THEN 'INACTIVO'
    END as 'estatus'
from productotiendas as productotienda
inner join vertiendas as tienda on productotienda.tienda = tienda.codigo
inner join productos as producto on productotienda.producto = producto.codigo;

create view verProductosTiendasActivos as
select * from verProductosTiendas where estatus = 'ACTIVO' 

create view verUsuarios as 
select 
    usuario.codigo, 
    usuario.usuario, 
    usuario.clave, 
    usuario.nombre, 
    usuario.apellido, 
    usuario.correo,
    tipousuario.descripcion as 'tipo_usuario',
    ciudad.nombre as 'ciudad',
    pais.nombre as 'pais',
    CASE
        WHEN usuario.estatus = 1 THEN 'ACTIVO'
        WHEN usuario.estatus = 0 THEN 'INACTIVO'
    END as 'estatus',
    tienda.nombre as 'tienda'
from usuarios as usuario
inner join tipoUsuarios as tipousuario on usuario.tipoUsuario = tipousuario.codigo
inner join ciudadesVer as ciudad on usuario.ciudad = ciudad.codigo
inner join verPaises as pais on ciudad.pais = pais.codigo
inner join verTiendas as tienda on usuario.tienda = tienda.codigo

create procedure agregarUsuario 
@codigoUsuario varchar(10), @usuario varchar(40), @clave varchar(40), @tipoUsuario varchar(2), @codigotienda varchar(10), @nombre varchar(40), @apellido varchar(40), @correo varchar(40), @ciudad varchar(4)
as
insert into usuarios(codigo, usuario, clave, tipoUsuario, estatus, tienda, nombre, apellido, correo, ciudad) 
values (@codigoUsuario, @usuario, @clave, @tipoUsuario, 1, @codigotienda, @nombre, @apellido, @correo, @ciudad)

create procedure modificarUsuario 
@codigo varchar(10), @usuario varchar(40), @clave varchar(40), @tipoUsuario varchar(2), @nombre varchar(40), @apellido varchar(40), @correo varchar(40), @ciudad varchar(4)
as
update usuarios set usuario = @usuario, clave = @clave, tipoUsuario = @tipousuario, nombre = @nombre, apellido = @apellido, correo = @correo, ciudad = @ciudad
where codigo = @codigo

create view verDetallesFacturas as
select 
    factura.codigo as 'codigo factura', 
    factura.tiempofacturacion as tiempo, 
    estatus.descripcion,
    productotienda.nombre,
    productotienda.codigo as 'codigo producto',
    productofacturado.codigo as 'codigo en factura',
    productofacturado.cantidad,
    productofacturado.precio,
    productofacturado.descuento,
    productofacturado.impuesto,
    CASE
        WHEN productofacturado.estatus = 1 THEN 'ACTIVO'
        WHEN productofacturado.estatus = 0 THEN 'INACTIVO'
    END as 'estatus',
    ((productofacturado.cantidad * productofacturado.precio)* (1 + productofacturado.impuesto)) - ((productofacturado.cantidad * productofacturado.precio)* productofacturado.descuento) as 'subtotal'
from facturas as factura 
inner join facturaestatus as estatus on factura.estatus = estatus.codigo
inner join productosfacturas as productofacturado on factura.codigo = productofacturado.factura
inner join verproductostiendas as productotienda on productofacturado.producto = productotienda.codigo

create view verimpuestos as
select 
    producto.nombre as 'producto',
    producto.codigo as 'codigo producto tienda',
    impuesto.codigo,
    impuesto.porcentage,
    CASE
        WHEN impuesto.estatus = 1 THEN 'ACTIVO'
        WHEN impuesto.estatus = 0 THEN 'INACTIVO'
    END as 'estatus'
from impuestosProductos as impuesto
inner join verProductosTiendas as producto on impuesto.producto = producto."codigo producto"

create view verimpuestosactivos as
select 
    *
from verimpuestos as impuesto
where impuesto.estatus = 'ACTIVO'

create view verdescuentos as
select 
    producto.nombre as 'producto',
    producto.codigo as 'codigo_producto_tienda',
    descuento.codigo,
    descuento.porcentage,
    CASE
        WHEN descuento.estatus = 1 THEN 'ACTIVO'
        WHEN descuento.estatus = 0 THEN 'INACTIVO'
    END as 'estatus'
from descuentosProductos as descuento
inner join verProductosTiendas as producto on descuento.producto = producto."codigo_producto"

create view verdescuentossactivos as
select 
    *
from verdescuentos as impuesto
where impuesto.estatus = 'ACTIVO'



create procedure tenerFactura @codigoFactura varchar(10) as
select * from verDetallesFacturas where "codigo factura" = @codigoFactura

create procedure tenerUsuario @codigoUsuario varchar(10) as
select * from verUsuarios where codigo = @codigoUsuario

create procedure tenerProducto @codigoProducto varchar(10) as
select * from verProductosTiendas where codigo = @codigoProducto

create procedure tenerTienda @codigoTienda varchar(10) as
select * from verTiendas where codigo = @codigoTienda

create procedure filtrarproducto @nombreProducto varchar(40) as
select * from verProductosTiendas where nombre like concat('%',@nombreProducto,'%')

create procedure ingresoUsuario @usuario varchar(40), @clave varchar(40) as 
select * from verUsuarios where usuario = @usuario and clave = @clave and estatus = 'ACTIVO'

create procedure agregarCiudad @codigo varchar(4), @nombre varchar(40), @codigopais varchar(4) as
insert into ciudades(codigo, nombre, pais) values (@codigo, @nombre, @codigopais);

create procedure eliminarCiudad @codigo varchar(4) as
delete from ciudades where codigo = @codigo

create procedure modificarCiudad @codigoNuevo varchar(4), @nombreNuevo varchar(40), @codigopaisNuevo varchar(4), @codigo varchar(4)  as
update ciudades set codigo = @codigoNuevo, nombre = @nombreNuevo, pais = @codigopaisNuevo where codigo = @codigo

create procedure agregarPais @codigo varchar(4), @nombre varchar(40)  as
insert into paises(codigo, nombre) values (@codigo, @nombre)

create procedure modificarPais @codigoNuevo varchar(4), @nombreNuevo varchar(40), @codigo varchar(4)  as
update paises set codigo = @codigoNuevo, nombre = @nombreNuevo where codigo = @codigo

create procedure agregarTienda @codigo varchar(10), @nombre varchar(40), @direccion text, @ciudad varchar(4) as
insert into tiendas(codigo, nombre, direccion, ciudad, estatus) values (@codigo, @nombre, @direccion, @ciudad, 1)

create procedure modificarTienda @codigo varchar(10), @nombrenuevo varchar(40), @direccionnueva text, @ciudadnueva varchar(4) as
update tiendas set nombre = @nombrenuevo, direccion = @direccionnueva, ciudad = @ciudadnueva where codigo = @codigo

create procedure agregarTiendaUsuario @codigoUsuario varchar(10), @usuario varchar(40), @clave varchar(40), @tipoUsuario varchar(2), @nombre varchar(40), @apellido varchar(40), @correo varchar(40), @ciudad varchar(4), @codigoTienda varchar(10), @nombreTienda varchar(40), @direccion text as 
begin
    exec agregarTienda @codigoTienda, @nombreTienda, @direccion, @ciudad;
    exec agregarUsuario @codigoUsuario, @usuario, @clave, @tipoUsuario, @codigotienda, @nombre, @apellido, @correo, @ciudad;
    
end

create procedure modificarTiendaUsuario @codigoUsuario varchar(10), @usuario varchar(40), @clave varchar(40), @tipoUsuario varchar(2), @nombre varchar(40), @apellido varchar(40), @correo varchar(40), @ciudad varchar(4), @codigoTienda varchar(10), @nombreTienda varchar(40), @direccion text as
begin
    exec modificarTienda @codigoTienda, @nombreTienda, @direccion, @ciudad;
    exec modificarUsuario @codigoUsuario, @usuario, @clave, @tipoUsuario, @nombre, @apellido, @correo, @ciudad;
end

create procedure agregarProductoTienda @codigoProducto varchar(10), @nombreProducto varchar(40), @codigoProductoTienda varchar(10), @codigoTienda varchar(10), @cantidad decimal(10), @precio decimal(10,2) as
begin
    insert into productos(codigo, nombre) values (@codigoProducto, @nombreProducto);
    insert into productotiendas(codigo, tienda, producto, estatus, cantidad, precio) values (@codigoProductoTienda, @codigoTienda, @codigoProducto, 1, @cantidad, @precio);
end

create procedure modificarProductoTienda @codigoProducto varchar(10), @nombreProductoNuevo varchar(40), @codigoProductoTienda varchar(10), @cantidad decimal(10), @precio decimal(10,2) as
BEGIN
    update productos set nombre = @nombreProductoNuevo where codigo = @codigoProducto;
    update productotiendas set cantidad = @cantidad, precio = @precio where codigo = @codigoProductoTienda;
END

create procedure eliminarProductoTienda @codigoProductoTienda varchar(10) as
update productotiendas set estatus = 0 where codigo = @codigoProductoTienda;

create procedure activarProductoTienda @codigoProductoTienda varchar(10) as
update productotiendas set estatus = 1 where codigo = @codigoProductoTienda;

create procedure activarusuario @codigo varchar(10), @estado BIT as
update usuarios set estatus = @estado where codigo = @codigo

create procedure activartienda @codigo varchar(10), @estado BIT as
update tiendas set estatus = @estado where codigo = @codigo

create procedure agregarTipoUsuario @codigo varchar(4), @descripcion varchar(40) as
insert into tipoUsuarios(codigo, descripcion) values (@codigo, @descripcion);

create procedure modificarTipoUsuario @codigo varchar(4), @descripcionnueva varchar(40) as
update tipoUsuarios set descripcion = @descripcionnueva where codigo = @codigo;

create procedure agregarFactura @codigo varchar(10), @tiempoFacturacion datetime2, @estatus varchar(4) as
insert into facturas(codigo, tiempoFacturacion, estatus) values (@codigo,@tiempoFacturacion, @estatus )

create procedure modificarFactura @codigo varchar(10), @tiempoFacturacion datetime2, @estatus varchar(4) as
update facturas set tiempoFacturacion = @tiempoFacturacion, estatus = @estatus where codigo = @codigo

create procedure pagarFactura @codigo varchar(10), @tiempoPago datetime2, @factura varchar(10), @total decimal(10,2) as
insert into pagoFacturas(codigo, tiempoPago, factura, totalPago) values (@codigo, @tiempoPago, @factura, @total)

create procedure modificarPagoFactura @codigo varchar(10), @tiempoPago datetime2, @factura varchar(10), @total decimal(10,2) as
update pagoFacturas set tiempoPago = @tiempoPago, factura = @factura, totalPago = @total where codigo = @codigo

create procedure agregarProductosFacturas @codigo varchar(10), @productotienda varchar(10), @factura varchar(10), @cantidad decimal(10), @precio decimal(10,2), @descuento decimal(10,2), @impuesto decimal(10,2) as
insert into productosFacturas(codigo, producto, factura, cantidad, precio, descuento, impuesto, estatus)values(@codigo, @productotienda, @factura, @cantidad, @precio, @descuento, @impuesto, 1)

create procedure quitarProductosFacturas @codigo varchar(10), @factura varchar(10) as
update productosFacturas set estatus = 0 where codigo = @codigo and factura = @factura

create procedure activarProductosFacturas @codigo varchar(10), @factura varchar(10) as
update productosFacturas set estatus = 1 where codigo = @codigo and factura = @factura

create procedure modificarProductosFacturas @codigo varchar(10), @productotienda varchar(10), @factura varchar(10), @cantidad decimal(10), @precio decimal(10,2), @descuento decimal(10,2), @impuesto decimal(10,2) as
update productosFacturas set producto = @productotienda, cantidad = @cantidad, precio = @precio, descuento = @descuento, impuesto = @impuesto where codigo = @codigo and factura = @factura

create procedure agregarImpuestoProductos @codigo varchar(10), @producto varchar(10), @porcentaje decimal(10,2) as
insert into impuestosProductos(codigo, producto, porcentage, estatus) values (@codigo,  @producto, @porcentaje, 1)

create procedure eliminarImpuestoProductos @codigo varchar(10) as
update impuestosProductos set estatus = 0 where codigo = @codigo;

create procedure activarImpuestoProductos @codigo varchar(10) as
update impuestosProductos set estatus = 1 where codigo = @codigo;

create procedure modificarImpuestoProductos @codigo varchar(10), @producto varchar(10), @porcentaje decimal(10,2) as
update impuestosProductos set estatus = 1, porcentage = @porcentaje, producto = @producto where codigo = @codigo;


create procedure agregardescuentosProductos @codigo varchar(10), @producto varchar(10), @porcentaje decimal(10,2) as
insert into descuentosProductos(codigo, producto, porcentage, estatus) values (@codigo,  @producto, @porcentaje, 1);

create procedure eliminardescuentosProductos @codigo varchar(10) as
update descuentosProductos set estatus = 0 where codigo = @codigo;

create procedure activardescuentosProductos @codigo varchar(10) as
update descuentosProductos set estatus = 1 where codigo = @codigo;

create procedure modificardescuentosProductos @codigo varchar(10), @producto varchar(10), @porcentaje decimal(10,2) as
update descuentosProductos set estatus = 1, porcentage = @porcentaje, producto = @producto where codigo = @codigo;

create procedure tenerImpuesto @producto varchar(10) as
select * from verimpuestos where "codigo producto tienda" = @producto

create procedure tenerdescuento @producto varchar(10) as
select * from verdescuentos where "codigo producto tienda" = @producto

