USE master
GO

IF NOT EXISTS (SELECT * FROM master.dbo.sysdatabases WHERE name = 'Repository') 
	BEGIN
		PRINT '>> database Repository not found; creating'
		CREATE DATABASE Repository
	END
GO

use Repository;
GO
  
IF not  EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Config]')  AND type IN ( N'U' ) )  
begin
print 'creating [Config]'  
CREATE TABLE [dbo].[Config](
	[Id] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[Id] ASC) ON [PRIMARY],
	[Name] [nvarchar](50) NULL,  
	[Value] [nvarchar](1000) NULL,
	[CreatedAt] [datetime] not null default(getdate()) ,
	[UpdatedAt] [datetime]  not null default(getdate()) 
	) ON [PRIMARY];


INSERT INTO  [Config] ( [Name], [Value] ) VALUES   
('SmtpServer', 'mail.Repository.com'),
('SmtpPort', '25'),
('ShowVideo', 'False') ;

End
GO

 

IF EXISTS (SELECT * FROM sys.procedures WHERE Name = 'GetConfigs' AND [type_desc] = 'SQL_STORED_PROCEDURE')
	DROP PROCEDURE GetConfigs;
GO
 
CREATE PROCEDURE GetConfigs  
		@name nvarchar(50)  
AS
 
 
declare @ErrorMessage nvarchar(500) = '';
BEGIN TRY 
	SET NOCOUNT ON;
	 
	SELECT TOP 1000 [Id]
		  ,[Name]
		  ,[Value]
		  ,[CreatedAt]
		  ,[UpdatedAt]
	  FROM [Config]
	  WHERE [Name] = @name;

END TRY
BEGIN CATCH
	DECLARE @error int;
	DECLARE @ErrorSeverity INT;

	SELECT @error = ERROR_NUMBER(),
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY();

	  RAISERROR (@ErrorMessage, -- Message text.
				 @ErrorSeverity, -- Severity.
				 1 -- State.
				 );
END CATCH

GO


