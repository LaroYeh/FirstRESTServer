# FirstRESTServer
Learn RESTful api with C#

I try follow this video and change a little bit.
https://www.youtube.com/playlist?list=PLDQIAo9A3-DaBMQ0ZZFlcej2we3uC5VT8

## Environment
1. Visual Studio 2017 +
2. SQL Server 2014 +
3. (suggest) Chrome with "Restlet Client".

## Build 
1. Ready environment.
2. Execute SQL test for following script: 
``` bash
CREATE TABLE [Person](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[PayRate] [decimal](18, 2) NULL,
	[StartDate] [datetime] NULL,
	[updDate] [datetime] NULL
) ON [PRIMARY] 
```
3. Open solution file "FirstRESTServer.sln".
4. Edit <connectionStrings> in ""Web.config" that can connect Instance. 

## What's different?
|---|Source|My|
|---|---|---|
|DB|MySQL|SQL Server|
|Table Schema|(bj4)|(bj4)|
|new Response|Request.CreateResponse|new HttpResponseMessage()|
