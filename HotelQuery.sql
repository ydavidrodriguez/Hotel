create table hotel
(
  Id int primary key identity(1,1),
  Nombre varchar(100),
  Direccion varchar(100),
  Telefono varchar(100),
  idciudad int,
  idpais int 
)

create table Ciudad
(
  Id int primary key identity(1,1),
  Nombre varchar(100),
  Idpais int

)
create table Pais
(
	Id int primary key identity(1,1),
	Nombre varchar(100)
)

-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE Listhoteles 
	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT h.Id,h.Nombre,h.Telefono,h.Direccion,c.Id,c.Nombre,p.Id,p.Nombre from hotel h
	inner join Ciudad c on h.idciudad = c.Id
	inner join Pais p on h.idciudad = p.Id  

	return 
END
GO


-- Author:		<Author,yeferson rodriguez>
-- Create date: <>
-- Description:	<Lista de Hoteles Filtrados>
-- =============================================
CREATE PROCEDURE FiltrarListhoteles 

@nombre varchar(100)	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT h.Id,h.Nombre,h.Telefono,h.Direccion,c.Id,c.Nombre,p.Id,p.Nombre from hotel h
	inner join Ciudad c on h.idciudad = c.Id
	inner join Pais p on h.idciudad = p.Id  
	where h.Nombre like '%' + RTRIM(@nombre) + '%'
	return 
END
GO