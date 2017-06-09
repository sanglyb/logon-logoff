
CREATE DATABASE [logon-logoff]
GO
USE [logon-logoff]
GO
/****** Object:  StoredProcedure [dbo].[InsertDBUserLoginUsers]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertDBUserLoginUsers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertDBUserLoginUsers]
GO
/****** Object:  StoredProcedure [dbo].[set_idle_time_for_app]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[set_idle_time_for_app]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[set_idle_time_for_app]
GO
/****** Object:  StoredProcedure [dbo].[UpdateDBUserLoginUsers]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateDBUserLoginUsers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateDBUserLoginUsers]
GO
/****** Object:  StoredProcedure [dbo].[get_idle_time_for_app]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_idle_time_for_app]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[get_idle_time_for_app]
GO
/****** Object:  Table [dbo].[DBUserLoginSettings]    Script Date: 07/14/2016 18:32:45 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBUserLoginSettings_idle_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBUserLoginSettings] DROP CONSTRAINT [DF_DBUserLoginSettings_idle_time]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLoginSettings]') AND type in (N'U'))
DROP TABLE [dbo].[DBUserLoginSettings]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteUser]
GO
/****** Object:  StoredProcedure [dbo].[realdatemin_sum]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[realdatemin_sum]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[realdatemin_sum]
GO
/****** Object:  StoredProcedure [dbo].[showall]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[showall]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[showall]
GO
/****** Object:  StoredProcedure [dbo].[showmin]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[showmin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[showmin]
GO
/****** Object:  StoredProcedure [dbo].[ShowMinNePodrobno]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShowMinNePodrobno]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ShowMinNePodrobno]
GO
/****** Object:  StoredProcedure [dbo].[showrdp]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[showrdp]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[showrdp]
GO
/****** Object:  StoredProcedure [dbo].[UpdateLates]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateLates]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateLates]
GO
/****** Object:  StoredProcedure [dbo].[WorkTimeUpdate]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkTimeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[WorkTimeUpdate]
GO
/****** Object:  StoredProcedure [dbo].[insert_into_dbuserlogin]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[insert_into_dbuserlogin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[insert_into_dbuserlogin]
GO
/****** Object:  Table [dbo].[DBUserLogin]    Script Date: 07/14/2016 18:32:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLogin]') AND type in (N'U'))
DROP TABLE [dbo].[DBUserLogin]
GO
/****** Object:  Table [dbo].[DBUserLoginMin]    Script Date: 07/14/2016 18:32:45 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBUserLoginMin_timediff]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBUserLoginMin] DROP CONSTRAINT [DF_DBUserLoginMin_timediff]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBUserLoginMin_onworkrealtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBUserLoginMin] DROP CONSTRAINT [DF_DBUserLoginMin_onworkrealtime]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBUserLoginMin_onworktimeint]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBUserLoginMin] DROP CONSTRAINT [DF_DBUserLoginMin_onworktimeint]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBUserLoginMin_onworkrealtimeint]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBUserLoginMin] DROP CONSTRAINT [DF_DBUserLoginMin_onworkrealtimeint]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLoginMin]') AND type in (N'U'))
DROP TABLE [dbo].[DBUserLoginMin]
GO
/****** Object:  Table [dbo].[DBUserLoginWithRDP]    Script Date: 07/14/2016 18:32:45 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBUserLoginWithRDP_onworktime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBUserLoginWithRDP] DROP CONSTRAINT [DF_DBUserLoginWithRDP_onworktime]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBUserLoginWithRDP_onworkrealtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBUserLoginWithRDP] DROP CONSTRAINT [DF_DBUserLoginWithRDP_onworkrealtime]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBUserLoginWithRDP_onworktimeint]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBUserLoginWithRDP] DROP CONSTRAINT [DF_DBUserLoginWithRDP_onworktimeint]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBUserLoginWithRDP_onworkrealtimeint]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBUserLoginWithRDP] DROP CONSTRAINT [DF_DBUserLoginWithRDP_onworkrealtimeint]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLoginWithRDP]') AND type in (N'U'))
DROP TABLE [dbo].[DBUserLoginWithRDP]
GO
/****** Object:  StoredProcedure [dbo].[workdatemin]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[workdatemin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[workdatemin]
GO
/****** Object:  Table [dbo].[DBUserLoginUsers]    Script Date: 07/14/2016 18:32:45 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBUserLoginUsers_usercomputer]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBUserLoginUsers] DROP CONSTRAINT [DF_DBUserLoginUsers_usercomputer]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLoginUsers]') AND type in (N'U'))
DROP TABLE [dbo].[DBUserLoginUsers]
GO
/****** Object:  Table [dbo].[DBUserLoginCheckLogin]    Script Date: 07/14/2016 18:32:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLoginCheckLogin]') AND type in (N'U'))
DROP TABLE [dbo].[DBUserLoginCheckLogin]
GO
/****** Object:  StoredProcedure [dbo].[reallatemin]    Script Date: 07/14/2016 18:32:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[reallatemin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[reallatemin]
GO
/****** Object:  StoredProcedure [dbo].[reallatemin]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[reallatemin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[reallatemin]
	@username NVARCHAR(50), @date datetime, @rdp bit, @realtime varchar(50) output, @realtimeint int output
AS
BEGIN	
/*set @timediff=(datediff(second,CAST(@logontime as time),cast(@logofftime as time)));

set @timediffdate=(CASE WHEN @timediff/3600<10 THEN ''0'' ELSE '''' END   
+ RTRIM(@timediff/3600)  + '':'' + RIGHT(''0''+RTRIM((@timediff % 3600) / 60),2)  
+ '':'' + RIGHT(''0''+RTRIM((@timediff % 3600) % 60),2))*/
declare @time datetime
declare @timediffdate varchar(50)
declare @logofftime datetime=getdate()
declare @logontime datetime=getdate()
declare @currcomp varchar(50)
declare @currtype varchar (50)
declare @prevtype varchar (50)
declare @prevcomp varchar(50)
declare @logon_count int = 0
declare @nexttime datetime=getdate()
declare @nexttype varchar(50)
declare @nextcomp varchar(50)
set @realtimeint=0
set @time=(select top (1) MIN(userdatetime) from DBUserLogin
	 where username=@username and CAST(userdatetime as date)=CAST(@date as date)
	 and (is_rdp=@rdp or is_rdp=0))
--set @time=''17.05.2016 16:57:00.0''
set @prevtype=''''
set @prevcomp=''''
while 
	(cast(@time as time))>=
	(select top (1) MIN(CAST(userdatetime as time)) from DBUserLogin
	 where username=@username and CAST(userdatetime as date)=CAST(@date as date)
	 and CAST(userdatetime as time)<=CAST(@time as time)
	 and (is_rdp=@rdp or is_rdp=0))
begin
select top (1) @currtype=login_type, @currcomp=usercomputer  from DBUserLogin where username=@username and userdatetime=@time
set @nexttime=(select top (1) MIN(userdatetime) from DBUserLogin
	 where username=@username and CAST(userdatetime as date)=CAST(@date as date)
		and CAST(userdatetime as time)>CAST(@time as time) and (is_rdp=@rdp or is_rdp=0))
select top (1) @nexttype=login_type, @nextcomp=usercomputer  from DBUserLogin where username=@username and userdatetime=@nexttime
if (@nexttime is null)
	begin
		set @nexttype='''';
		set @nextcomp='''';
	end

	if @currtype=''logon''
	begin	
		if not(@prevtype=@currtype and @prevcomp=@currcomp)
		begin
			if @logon_count<0
			begin
				set @logon_count=0;
			end
			if @logon_count=0
			begin
				set @logontime=(select top (1) MAX(userdatetime) from DBUserLogin
						where username=@username and CAST(userdatetime as date)=CAST(@date as date)
							and CAST(userdatetime as time)<=CAST(@time as time)						
							and login_type=''logon'' and (is_rdp=@rdp or is_rdp=0)						
							)
			end
			set @logon_count=@logon_count+1		
		end
	end
	
	
	if @currtype=''logoff''
	if not(@nexttype=@currtype and @nextcomp=@currcomp)
	begin
		set @logon_count=@logon_count-1	
		if @logon_count=0
		begin
			set @logofftime=(select top (1) MAX(userdatetime) from DBUserLogin
					where username=@username and CAST(userdatetime as date)=CAST(@date as date)
						and CAST(userdatetime as time)<=CAST(@time as time)						
						and login_type=''logoff'' and (is_rdp=@rdp or is_rdp=0)						
						)
		end
				
	end
	if (@logon_count=0 and @currtype=''logoff'')
		begin
			set @realtimeint=(@realtimeint+(datediff(second,CAST(@logontime as time),cast(@logofftime as time))));			
		end
		
	select top (1) 
		@prevtype=login_type, @prevcomp=usercomputer  
	from 
		DBUserLogin 
	where 
		username=@username and userdatetime=@time
		
	set @time=(select top (1) MIN(userdatetime) from DBUserLogin
		 where username=@username and CAST(userdatetime as date)=CAST(@date as date)
			and CAST(userdatetime as time)>CAST(@time as time) and (is_rdp=@rdp or is_rdp=0))				
end 

set @timediffdate=(CASE WHEN @realtimeint/3600<10 THEN ''0'' ELSE '''' END   
+ RTRIM(@realtimeint/3600)  + '':'' + RIGHT(''0''+RTRIM((@realtimeint % 3600) / 60),2)  
+ '':'' + RIGHT(''0''+RTRIM((@realtimeint % 3600) % 60),2))
set @realtime=@timediffdate
return 
END
' 
END
GO
/****** Object:  Table [dbo].[DBUserLoginCheckLogin]    Script Date: 07/14/2016 18:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLoginCheckLogin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DBUserLoginCheckLogin](
	[username] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[usercomputer] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[DBUserLoginUsers]    Script Date: 07/14/2016 18:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLoginUsers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DBUserLoginUsers](
	[surname] [nvarchar](100) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[name] [nvarchar](100) COLLATE Cyrillic_General_CI_AS NULL,
	[secondname] [nvarchar](100) COLLATE Cyrillic_General_CI_AS NULL,
	[workstart] [time](7) NOT NULL,
	[workend] [time](7) NOT NULL,
	[username1] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[usercomputer] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL CONSTRAINT [DF_DBUserLoginUsers_usercomputer]  DEFAULT ('')
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[workdatemin]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[workdatemin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[workdatemin]
	@username NVARCHAR(50), @startdate datetime, @rdp bit, @onwork varchar(50) output, @onworkint int output
AS
BEGIN	
declare @logontime datetime
declare @logofftime datetime
if (@rdp=0)
begin
set @logontime=(select userdatetime 
					from DBUserLoginMin 
					where username=@username 
						and cast(userdatetime as DATE)=(select cast(@startdate as date)))
set @logofftime=(select logofftime 
					from DBUserLoginMin 
					where username=@username 
						and cast(userdatetime as DATE)=(select cast(@startdate as date)))
set @onworkint=(datediff(second,CAST(@logontime as time),cast(@logofftime as time)));

set @onwork=(CASE WHEN @onworkint/3600<10 THEN ''0'' ELSE '''' END   
+ RTRIM(@onworkint/3600)  + '':'' + RIGHT(''0''+RTRIM((@onworkint % 3600) / 60),2)  
+ '':'' + RIGHT(''0''+RTRIM((@onworkint % 3600) % 60),2))
end
else
begin
set @logontime=(select userdatetime 
					from DBUserLoginWithRDP 
					where username=@username 
						and cast(userdatetime as DATE)=(select cast(@startdate as date)))
set @logofftime=(select logofftime 
					from DBUserLoginWithRDP 
					where username=@username 
						and cast(userdatetime as DATE)=(select cast(@startdate as date)))
set @onworkint=(datediff(second,CAST(@logontime as time),cast(@logofftime as time)));

set @onwork=(CASE WHEN @onworkint/3600<10 THEN ''0'' ELSE '''' END   
+ RTRIM(@onworkint/3600)  + '':'' + RIGHT(''0''+RTRIM((@onworkint % 3600) / 60),2)  
+ '':'' + RIGHT(''0''+RTRIM((@onworkint % 3600) % 60),2))
end
return 
END
' 
END
GO
/****** Object:  Table [dbo].[DBUserLoginWithRDP]    Script Date: 07/14/2016 18:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLoginWithRDP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DBUserLoginWithRDP](
	[username] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[userdatetime] [datetime] NULL,
	[logofftime] [datetime] NULL,
	[is_late] [bit] NULL,
	[onworktime] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL CONSTRAINT [DF_DBUserLoginWithRDP_onworktime]  DEFAULT ('00:00:00'),
	[onworkrealtime] [varchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL CONSTRAINT [DF_DBUserLoginWithRDP_onworkrealtime]  DEFAULT ('00:00:00'),
	[onworktimeint] [int] NOT NULL CONSTRAINT [DF_DBUserLoginWithRDP_onworktimeint]  DEFAULT ((0)),
	[onworkrealtimeint] [int] NOT NULL CONSTRAINT [DF_DBUserLoginWithRDP_onworkrealtimeint]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DBUserLoginMin]    Script Date: 07/14/2016 18:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLoginMin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DBUserLoginMin](
	[username] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[userdatetime] [datetime] NULL,
	[logofftime] [datetime] NULL,
	[is_late] [bit] NULL,
	[onworktime] [varchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL CONSTRAINT [DF_DBUserLoginMin_timediff]  DEFAULT ('00:00:00'),
	[onworkrealtime] [varchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL CONSTRAINT [DF_DBUserLoginMin_onworkrealtime]  DEFAULT ('00:00:00'),
	[onworktimeint] [int] NOT NULL CONSTRAINT [DF_DBUserLoginMin_onworktimeint]  DEFAULT ((0)),
	[onworkrealtimeint] [int] NOT NULL CONSTRAINT [DF_DBUserLoginMin_onworkrealtimeint]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DBUserLogin]    Script Date: 07/14/2016 18:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLogin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DBUserLogin](
	[username] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[usercomputer] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[userdatetime] [datetime] NOT NULL,
	[login_type] [nvarchar](20) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[is_rdp] [bit] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[insert_into_dbuserlogin]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[insert_into_dbuserlogin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[insert_into_dbuserlogin]
	@username varchar(50),
	@computername varchar(50),
	@type varchar(50),
	@is_rdp bit,
	@first bit	
AS
BEGIN	 
declare @times_num int
declare @date datetime=(getdate())
declare @prevrdp bit
declare @userdatetime datetime
declare @prevlogintype varchar(50)
if (@type=''logon'' and @first=1)
begin
	set @date=(getdate()-''00:00:20.00'')
end

set @userdatetime = (
	select top 1 MAX(userdatetime) 
	from DBUserLogin 
	where 
		cast(@date as date)=cast(userdatetime as date) and 
		cast(@date as time)>cast(userdatetime as time) and 
		username=@username and 
		usercomputer=@computername
	)
--новое
set @times_num = (
	select COUNT(userdatetime)
	from DBUserLogin 
	where 
		@userdatetime =userdatetime and 		
		username=@username and 
		usercomputer=@computername
	)
if (@times_num>1)
	begin 
		while (@times_num>1)
		begin
	delete top (1) 
	from DBUserLogin
	where 
		@userdatetime=userdatetime and 
		username=@username and 
		usercomputer=@computername	
	set @times_num = (
	select COUNT(userdatetime)
	from DBUserLogin 
	where 
		@userdatetime =userdatetime and 
		username=@username and 
		usercomputer=@computername
	)
		end
	end
--старое
set @prevrdp=(
	select is_rdp
	from DBUserLogin 
	where 
		username=@username and 
		usercomputer=@computername and 
		userdatetime=@userdatetime
		)
set @prevlogintype=(
	select login_type
	from DBUserLogin 
	where 
		username=@username and 
		usercomputer=@computername and 
		userdatetime=@userdatetime
		)

if ((@prevlogintype!=@type and (@prevrdp=@is_rdp or @type=''logon''))or(@userdatetime is null))
	begin		
		INSERT INTO DbUserLogin(username, usercomputer, userdatetime, login_type, is_rdp) 
			VALUES(@username, @computername, @date, @type, @is_rdp)
	end
else if(@prevrdp!=@is_rdp and @prevlogintype!=@type and @type=''logoff'')
	begin
		INSERT INTO DbUserLogin(username, usercomputer, userdatetime, login_type, is_rdp) 
			VALUES(@username, @computername, @date, @type, @prevrdp)
	end
/*else if(@prevlogintype=@type and @type=''logoff'')
	begin
		DELETE from DBUserLogin where (username=@username and userdatetime=@userdatetime)
		INSERT INTO DbUserLogin(username, usercomputer, userdatetime, login_type, is_rdp) 
			VALUES(@username, @computername,@date, @type, @is_rdp)		
	end*/
END' 
END
GO
/****** Object:  Trigger [on_work_time]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[on_work_time]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[on_work_time] ON [dbo].[DBUserLoginMin]
FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON
declare @timediff int
declare @timediffdate varchar(50)
declare @startdate datetime
declare @username nvarchar(50)
declare @logontime datetime
declare @logofftime datetime
set @startdate=(select userdatetime from inserted)
set @username=(select username from inserted)
set @logontime=(select userdatetime 
					from DBUserLoginMin 
					where username=@username 
						and cast(userdatetime as DATE)=(select cast(@startdate as date)))
set @logofftime=(select logofftime 
					from DBUserLoginMin 
					where username=@username 
						and cast(userdatetime as DATE)=(select cast(@startdate as date)))
set @timediff=(datediff(second,CAST(@logontime as time),cast(@logofftime as time)));

set @timediffdate=(CASE WHEN @timediff/3600<10 THEN ''0'' ELSE '''' END   
+ RTRIM(@timediff/3600)  + '':'' + RIGHT(''0''+RTRIM((@timediff % 3600) / 60),2)  
+ '':'' + RIGHT(''0''+RTRIM((@timediff % 3600) % 60),2))

update DBUserLoginMin set onworktime=@timediffdate where username=@username and cast(userdatetime as date)=(select cast(@startdate as date))
'
GO
/****** Object:  StoredProcedure [dbo].[WorkTimeUpdate]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkTimeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[WorkTimeUpdate]
	@username NVARCHAR(50)
AS
BEGIN
declare @realtime varchar(50)
declare @realtimeint int
declare @worktime varchar(50)
declare @worktimeint int
declare @mindate datetime
set @mindate=(select min(userdatetime) from DBUserLoginWithRDP where 
				username=@username)
	while 
		((cast(@mindate as date))>=
		(select top 1 MIN(CAST(userdatetime as DATE)) from DBUserLoginWithRDP
		where username=@username))
	begin
	exec reallatemin
		@username=@username, @date=@mindate, @rdp=1, @realtime=@realtime output, @realtimeint=@realtimeint output
	exec workdatemin
		@username=@username, @startdate=@mindate, @rdp=1, @onwork=@worktime output, @onworkint=@worktimeint output
	update DBUserLoginWithRDP set onworkrealtimeint=@realtimeint, onworkrealtime=@realtime, 
		onworktime=@worktime, onworktimeint=@worktimeint 
		where username=@username and userdatetime=@mindate
	
	set @mindate=(select top 1 min(userdatetime) from DBUserLoginWithRDP where 
				username=@username and CAST(userdatetime as date)>CAST(@mindate as date))
	
	end
	
set @mindate=(select top 1 min(userdatetime) from DBUserLoginMin where 
				username=@username)
	while 
		((cast(@mindate as date))>=
		(select top 1 MIN(CAST(userdatetime as DATE)) from DBUserLoginMin
		where username=@username))		
	begin
	print @mindate
	exec reallatemin
	@username=@username, @date=@mindate, @rdp=0, @realtime=@realtime output, @realtimeint=@realtimeint output
	exec workdatemin
	@username=@username, @startdate=@mindate, @rdp=0, @onwork=@worktime output, @onworkint=@worktimeint output
	update DBUserLoginMin set onworkrealtimeint=@realtimeint, onworkrealtime=@realtime, 
		onworktime=@worktime, onworktimeint=@worktimeint 
		where username=@username and userdatetime=@mindate
	
	set @mindate=(select top 1 min(userdatetime) from DBUserLoginMin where 
				username=@username and CAST(userdatetime as date)>CAST(@mindate as date))
	
	end

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateLates]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateLates]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateLates]
	@username NVARCHAR(50)
AS
BEGIN
	declare @date datetime

set @date=GETDATE();
while 
	((cast(@date as DATE))>=
	(select MIN(CAST(userdatetime as date)) from DBUserLoginWithRDP
	 where username=@username))
begin	
	if ((select CAST(userdatetime as time) from DBUserLoginWithRDP 
		where username=@username 
				and CAST(userdatetime as date)=cast(@date as DATE))
		<=(select workstart
			from DBUserLoginUsers where username1=@username)) and
			((select CAST(logofftime as time) from DBUserLoginWithRDP 
		where username=@username 
				and CAST(logofftime as date)=cast(@date as DATE))
		>=(select workend
			from DBUserLoginUsers where username1=@username))					
	begin
		update DBUserLoginWithRDP set is_late=''0'' where username=@username 
			and CAST(userdatetime as DATE) = cast(@date as DATE)
	end
	else 
	begin
	update DBUserLoginWithRDP set is_late=''1'' where username=@username 
			and CAST(userdatetime as DATE) = cast(@date as DATE)
	end
	
	if 
		((select CAST(userdatetime as time) from DBUserLoginMin 
		where username=@username 
				and CAST(userdatetime as date)=cast(@date as DATE))
		<=(select workstart
			from DBUserLoginUsers where username1=@username)) and
			((select CAST(logofftime as time) from DBUserLoginMin 
		where username=@username 
				and CAST(logofftime as date)=cast(@date as DATE))
		>=(select workend
			from DBUserLoginUsers where username1=@username))					
	begin
		update DBUserLoginMin set is_late=''0'' where username=@username 
			and CAST(userdatetime as DATE) = cast(@date as DATE)
	end
	else 
	begin
		update DBUserLoginMin set is_late=''1'' where username=@username 
			and CAST(userdatetime as DATE) = cast(@date as DATE)
	end
set @date=@date-1
end
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[showrdp]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[showrdp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[showrdp]
	@mindate date,
	@maxdate date,	
	@username nvarchar(50)
AS
BEGIN	      
            
select 
	DBUserLoginUsers.surname as ''Фамилия'', 
	cast(DbUserLoginWithRDP.userdatetime as DATE) as ''Дата'', 
    cast(DbUserLoginWithRDP.userdatetime as time) as ''Первый логон'',
    cast(DbUserLoginWithRDP.logofftime as time) as ''Последний логофф'', 
    DBUserLoginWithRDP.is_late as ''Опоздал'',
    DBUserLoginWithRDP.onworktime as ''Время на работе'',
    DBUserLoginWithRDP.onworkrealtime as ''Время за компьютером''
from 
	DBUserLoginUsers, DbUserLoginWithRDP 
where 
	(DBUserLoginUsers.username1 = DbUserLoginWithRDP.username 
     and (cast(DBUserLoginWithRDP.userdatetime as date)>=@mindate) 
     and (cast(DBUserLoginWithRDP.userdatetime as date)<=@maxdate)
     and DBUserLoginUsers.surname like @username) 
order by 
	cast(DbUserLoginWithRDP.userdatetime as date) desc, DBUserLoginUsers.surname               
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ShowMinNePodrobno]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShowMinNePodrobno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ShowMinNePodrobno]
	@is_rdp varchar(50),
	@mindate date,
	@maxdate date
AS
BEGIN
if (@is_rdp=''0'')
begin
SELECT
 distinct c.surname as surname,
(SELECT 
	cast(cast(userdatetime as date)as varchar(50)) + '','', 
	cast(cast(userdatetime as time(0)) as varchar(50))+'','', 
	cast(cast(logofftime as time(0)) as varchar(50)) + '','',
	cast(is_late as varchar(50)) + '','',
	CAST(onworkrealtimeint as varchar(50)) + '','',
	CAST (onworktimeint as varchar(50))+'';''
			
 FROM DBUserLoginMin
 WHERE 
	username=e.username and 
	@mindate<=CAST(userdatetime as date) and 
	@maxdate>=CAST(userdatetime as date)
 order by 
	userdatetime desc
 FOR XML PATH('''') ) as times
	FROM DBUserLoginMin e, DBUserLoginUsers c
	where 
		e.username=c.username1 and
		@mindate<=CAST(userdatetime as date) and 
		@maxdate>=CAST(userdatetime as date)
end
else
begin
SELECT
 distinct c.surname,
(SELECT 
	cast(cast(userdatetime as date)as varchar(50)) + '','', 
	cast(cast(userdatetime as time(0)) as varchar(50))+'','', 
	cast(cast(logofftime as time(0)) as varchar(50)) + '','',
	cast(is_late as varchar(50)) + '','',
	CAST(onworkrealtimeint as varchar(50)) + '','',
	CAST (onworktimeint as varchar(50))+'';''
			
 FROM DBUserLoginWithRDP
 WHERE 
	username=e.username and 
	@mindate<=CAST(userdatetime as date) and 
	@maxdate>=CAST(userdatetime as date)
 order by 
	userdatetime desc
 FOR XML PATH('''') ) as times
	FROM DBUserLoginWithRDP e, DBUserLoginUsers c
	where 
		e.username=c.username1 and
		@mindate<=CAST(userdatetime as date) and 
		@maxdate>=CAST(userdatetime as date)

end
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[showmin]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[showmin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[showmin]
	@mindate date,
	@maxdate date,	
	@username nvarchar(50)
AS
BEGIN	      
            
select 
	DBUserLoginUsers.surname as ''Фамилия'', 
	cast(DBUserLoginMin.userdatetime as DATE) as ''Дата'', 
    cast(DBUserLoginMin.userdatetime as time) as ''Первый логон'',
    cast(DBUserLoginMin.logofftime as time) as ''Последний логофф'', 
    DBUserLoginMin.is_late as ''Опоздал'',
    DBUserLoginMin.onworktime as ''Время на работе'',
    DBUserLoginMin.onworkrealtime as ''Время за компьютером''
from 
	DBUserLoginUsers, DBUserLoginMin 
where 
	(DBUserLoginUsers.username1 = DBUserLoginMin.username 
     and (cast(DBUserLoginMin.userdatetime as date)>=@mindate) 
     and (cast(DBUserLoginMin.userdatetime as date)<=@maxdate)
     and DBUserLoginUsers.surname like @username) 
order by 
	DBUserLoginUsers.surname, cast(DBUserLoginMin.userdatetime as date) desc
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[showall]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[showall]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[showall]
	@mindate date,
	@maxdate date,
	@is_rdp nvarchar(50),
	@username nvarchar(50)
AS
BEGIN	      
            
select 
	DBUserLoginUsers.surname as ''Фамилия'', 
	DBUserLogin.usercomputer as ''Компьютер'', 
	cast(DBUserLogin.userdatetime as DATE) as ''Дата'',
	cast(DBUserLogin.userdatetime as time) as ''Время'', 
	DBUserLogin.login_type as ''Логон/Логофф'', 
	DBUserLogin.is_rdp as ''RDP''
from 
	DBUserLoginUsers, DBUserLogin 
where 
		(DBUserLoginUsers.username1=DBUserLogin.username
	and 
		(DBUserLogin.is_rdp like @is_rdp or 
		DBUserLogin.is_rdp=0) 
	and 
		DBUserLoginUsers.surname like @username
	and (cast(DBUserLogin.userdatetime as date)>=@mindate)
	and (cast(DBUserLogin.userdatetime as date)<=@maxdate)
) 
order by 
	DBUserLoginUsers.surname desc, 
	cast(DBUserLogin.userdatetime as DATE) desc, 	 
	cast(DBUserLogin.userdatetime as time) desc;                
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[realdatemin_sum]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[realdatemin_sum]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[realdatemin_sum]
	@surname NVARCHAR(50), @mindate date, @enddate date, @rdp bit
AS
BEGIN
declare @sum_real_time int
declare @sum_work_time int
declare @real_time varchar(50)
declare @work_time varchar(50)
declare @username varchar(50)
declare @late_count int
declare @not_full_time_count int
set @username=(select username1 from DBUserLoginUsers where surname=@surname)

if @rdp!=0
	begin
	set @sum_real_time=
		(select SUM(onworkrealtimeint) from DBUserLoginWithRDP
			where username=@username and cast(userdatetime as DATE)>=@mindate and cast(userdatetime as DATE)<=@enddate)
	set @sum_work_time=
		(select SUM(onworktimeint) from DBUserLoginWithRDP
			where username=@username and cast(userdatetime as DATE)>=@mindate and cast(userdatetime as DATE)<=@enddate)
	set @late_count=(select COUNT(*) from DBUserLoginWithRDP 
		where username=@username and cast(userdatetime as DATE)>=@mindate and cast(userdatetime as DATE)<=@enddate and is_late=1
		and (DATEDIFF(DAY,0, userdatetime)%7)!=''5'' and (DATEDIFF(DAY,0, userdatetime)%7)!=''6'')
	set @not_full_time_count=(select COUNT(*) from DBUserLoginWithRDP
		where username=@username and cast(userdatetime as DATE)>=@mindate and cast(userdatetime as DATE)<=@enddate and 
		onworktimeint<32400 and (DATEDIFF(DAY,0, userdatetime)%7)!=''5'' and (DATEDIFF(DAY,0, userdatetime)%7)!=''6'')
	end
else
begin
		begin
	set @sum_real_time=
		(select SUM(onworkrealtimeint) from DBUserLoginMin
			where username=@username and cast(userdatetime as DATE)>=@mindate and cast(userdatetime as DATE)<=@enddate)
	set @sum_work_time=
		(select SUM(onworktimeint) from DBUserLoginMin
			where username=@username and cast(userdatetime as DATE)>=@mindate and cast(userdatetime as DATE)<=@enddate)
	set @late_count=(select COUNT(*) from DBUserLoginMin 
		where username=@username and cast(userdatetime as DATE)>=@mindate and cast(userdatetime as DATE)<=@enddate and is_late=1
		and (DATEDIFF(DAY,0, userdatetime)%7)!=''5'' and (DATEDIFF(DAY,0, userdatetime)%7)!=''6'')
	
	set @not_full_time_count=(select COUNT(*) from DBUserLoginMin
	where username=@username and cast(userdatetime as DATE)>=@mindate and cast(userdatetime as DATE)<=@enddate and 
	onworktimeint<32400 and (DATEDIFF(DAY,0, userdatetime)%7)!=''5'' and (DATEDIFF(DAY,0, userdatetime)%7)!=''6'')
	end
end
set @real_time=(CASE WHEN @sum_real_time/3600<10 THEN ''0'' ELSE '''' END   
	+ RTRIM(@sum_real_time/3600)  + '':'' + RIGHT(''0''+RTRIM((@sum_real_time % 3600) / 60),2)  
	+ '':'' + RIGHT(''0''+RTRIM((@sum_real_time % 3600) % 60),2))
set @work_time=(CASE WHEN @sum_work_time/3600<10 THEN ''0'' ELSE '''' END   
	+ RTRIM(@sum_work_time/3600)  + '':'' + RIGHT(''0''+RTRIM((@sum_work_time % 3600) / 60),2)  
	+ '':'' + RIGHT(''0''+RTRIM((@sum_work_time % 3600) % 60),2))
select @real_time as ''Реальное время'', @work_time as ''Время на работе'', @late_count as ''Количество опозданий/ранних уходов'',
		@not_full_time_count as ''Количество неполных часов''
END' 
END
GO
/****** Object:  Trigger [is_late_trig]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[is_late_trig]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[is_late_trig] ON [dbo].[DBUserLoginMin]
FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON
declare @late bit
set @late = ''1''
if (select CAST(userdatetime as time) from inserted)<=(select cast(workstart	as time)
		from DBUserLoginUsers where username1=(select username from inserted))
	and (select CAST(logofftime as time) from inserted)>=(select cast(workend as time)
		from DBUserLoginUsers where username1=(select username from inserted))
begin
set @late=0
update DBUserLoginMin set DBUserLoginMin.is_late=@late 
	where ((DBUserLoginMin.username=(select username from inserted))
		and (CAST(DBUserLoginMin.userdatetime as DATE)=(
		select cast(userdatetime as DATE) from inserted)))		
end
else
begin
set @late=1
update DBUserLoginMin set DBUserLoginMin.is_late=@late 
	where ((DBUserLoginMin.username=(select username from inserted))
		and (CAST(DBUserLoginMin.userdatetime as DATE)=(
		select cast(userdatetime as DATE) from inserted)))		
end
--время
declare @startdate datetime
declare @username nvarchar(50)
set @startdate=(select userdatetime from inserted)
set @username=(select username from inserted)

declare @onworktime varchar(50)
declare @onworktimeint int
exec workdatemin 
	@username=@username, 
	@startdate=@startdate, 
	@rdp=0, 
	@onwork=@onworktime output, 
	@onworkint=@onworktimeint output

declare @realtime nvarchar(50)
declare @realtimeint int
exec reallatemin 
	@username=@username, 
	@date=@startdate, 
	@rdp=0,
	@realtime=@realtime output, 
	@realtimeint=@realtimeint output
update DBUserLoginMin set 
	onworktimeint=@onworktimeint, onworkrealtimeint=@realtimeint, onworktime=@onworktime, onworkrealtime=@realtime where username=@username and cast(userdatetime as date)=(select cast(@startdate as date))'
GO
/****** Object:  Trigger [is_late_late_trig]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[is_late_late_trig]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[is_late_late_trig] ON [dbo].[DBUserLoginWithRDP]
FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON
declare @late bit
set @late = ''1''
if (select CAST(userdatetime as time) from inserted)<=(select cast(workstart	as time)
		from DBUserLoginUsers where username1=(select username from inserted))
	and (select CAST(logofftime as time) from inserted)>=(select cast(workend as time)
		from DBUserLoginUsers where username1=(select username from inserted))
begin
set @late=0
update DBUserLoginWithRDP set DBUserLoginWithRDP.is_late=@late 
	where ((DBUserLoginWithRDP.username=(select username from inserted))
		and (CAST(DBUserLoginWithRDP.userdatetime as DATE)=(
		select cast(userdatetime as DATE) from inserted)))		
end
else 
begin
set @late=1
update DBUserLoginWithRDP set DBUserLoginWithRDP.is_late=@late 
	where ((DBUserLoginWithRDP.username=(select username from inserted))
		and (CAST(DBUserLoginWithRDP.userdatetime as DATE)=(
		select cast(userdatetime as DATE) from inserted)))		
end

--время
declare @startdate datetime
declare @username nvarchar(50)
set @startdate=(select userdatetime from inserted)
set @username=(select username from inserted)

declare @onworktime varchar(50)
declare @onworktimeint int
exec workdatemin 
	@username=@username, 
	@startdate=@startdate, 
	@rdp=1, 
	@onwork=@onworktime output, 
	@onworkint=@onworktimeint output

declare @realtime nvarchar(50)
declare @realtimeint int
exec reallatemin 
	@username=@username, 
	@date=@startdate, 
	@rdp=1,
	@realtime=@realtime output, 
	@realtimeint=@realtimeint output
update DBUserLoginWithRDP set 
	onworktimeint=@onworktimeint, onworkrealtimeint=@realtimeint, onworktime=@onworktime, onworkrealtime=@realtime where username=@username and cast(userdatetime as date)=(select cast(@startdate as date))
'
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DeleteUser]
	@usersurname NVARCHAR(50),
	@username NVARCHAR(50)
AS
BEGIN
	delete from dbuserloginusers where (surname=@usersurname and username1=@username);
	delete from dbuserlogin where username=@username;
	delete from dbuserloginmin where username=@username;
	delete from dbuserloginwithrdp where username=@username;
END
' 
END
GO
/****** Object:  Table [dbo].[DBUserLoginSettings]    Script Date: 07/14/2016 18:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUserLoginSettings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DBUserLoginSettings](
	[idle_time] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL CONSTRAINT [DF_DBUserLoginSettings_idle_time]  DEFAULT (N'00:05:00')
) ON [PRIMARY]
END
GO
/****** Object:  Trigger [login_create_users]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[login_create_users]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[login_create_users] ON [dbo].[DBUserLogin]
FOR INSERT
AS
SET NOCOUNT ON
if not exists (select * from DBUserLoginUsers where 
	(username1=(select username from inserted)))
begin
insert into DBUserLoginUsers (surname, name, secondname, workstart, workend, username1, usercomputer) 
	values ((select username from inserted), '''', '''', ''10:00:00'', ''19:00:00'', 
	(select username from inserted), (select usercomputer from inserted));
end


declare @login_type varchar(50)=(select login_type from inserted);
declare @is_rdp bit = (select is_rdp from inserted);
declare @username varchar(50) = (select username from inserted);
declare @usercomputer varchar(50) = (select usercomputer from inserted);
declare @userdatetime datetime=(select userdatetime from inserted);
if (@login_type=''logon'' and
		not exists (select * from DBUserLoginCheckLogin where (username=@username and usercomputer=@usercomputer)))
	begin
	insert into DBUserLoginCheckLogin (username, usercomputer)
		values (@username, @usercomputer)	
	end
else 
	begin
		delete from DBUserLoginCheckLogin where (username=@username and usercomputer=@usercomputer)
	end

	'
GO
/****** Object:  Trigger [login_copy]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[login_copy]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[login_copy] ON [dbo].[DBUserLogin]
FOR INSERT
AS
SET NOCOUNT ON

declare @username varchar(50) = (select username from inserted) 
declare @userdatetime datetime = (select userdatetime from inserted)
declare @userdate date=cast((select userdatetime from inserted) as date)
declare @is_rdp bit = (select is_rdp from inserted)
declare @login_type varchar(50) = (select login_type from inserted)
declare @usercomputer varchar(50)=(select usercomputer from inserted)
--добавление записей в таблицы Min и RDP
if (@is_rdp=0)
begin
if (not exists (
	select 1 from DbUserLoginMin 
	where 
		username=@username 
		and cast(userdatetime as DATE)=@userdate))		
	begin
		insert into DbUserLoginMin (username, userdatetime, logofftime, is_late)
			values (@username, @userdatetime, @userdatetime, 1)
	end
else
	begin
		update DbUserLoginMin set logofftime=@userdatetime where username=@username and cast(userdatetime as date)=@userdate
	end
end

if (not exists (
	select 1 from DBUserLoginWithRDP 
	where 
		username=@username 
		and cast(userdatetime as DATE)=@userdate))		
	begin
		insert into DBUserLoginWithRDP (username, userdatetime, logofftime, is_late)
			values (@username, @userdatetime, @userdatetime, 1)
	end
else
	begin
		update DBUserLoginWithRDP set logofftime=@userdatetime where username=@username and cast(userdatetime as date)=@userdate
	end
	
--Добавление пользователя в DBUserLoginUsers	
declare @username1 varchar(50)=(select username from inserted)
if not exists (select 1 from DBUserLoginUsers where 
	(username1=@username1))
begin
insert into DBUserLoginUsers (surname, name, secondname, workstart, workend, username1, usercomputer) 
	values (@username1, '''', '''', ''10:00:00'', ''19:00:00'', 
	@username1, @usercomputer);
end

--Добавление записи в CheckLogin
if (@login_type=''logon'' and
		not exists (select * from DBUserLoginCheckLogin where (username=@username and usercomputer=@usercomputer)))
	begin
	insert into DBUserLoginCheckLogin (username, usercomputer)
		values (@username, @usercomputer)	
	end
else 
	begin
		delete from DBUserLoginCheckLogin where (username=@username and usercomputer=@usercomputer)
	end
'
GO
/****** Object:  StoredProcedure [dbo].[get_idle_time_for_app]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_idle_time_for_app]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[get_idle_time_for_app]
as
begin
	if (exists(select top (1) idle_time from DBUserLoginSettings))
		begin
			select top (1) idle_time from DBUserLoginSettings
		end
	else
		begin
			select ''05:00:00''
		end
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateDBUserLoginUsers]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateDBUserLoginUsers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateDBUserLoginUsers]
	@surname NVARCHAR(50),
	@name NVARCHAR(50),
	@secondname NVARCHAR(50),
	@workstart NVARCHAR(50),
	@workend NVARCHAR(50),
	@username1 NVARCHAR(50),
	@oldsurname nvarchar(50),
	@oldusername nvarchar(50),
	@computername nvarchar(50)
AS
BEGIN
	update DBUserLoginUsers set 
		surname=@surname, 
		name=@name, 
		secondname=@secondname, 
		workstart=@workstart, 
		workend=@workend, 
		username1=@username1,
		usercomputer=@computername
	where 
		surname=@oldsurname and username1=@oldusername;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[set_idle_time_for_app]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[set_idle_time_for_app]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[set_idle_time_for_app]
@idle_time varchar(50)
as
begin
	if (exists(select top (1) idle_time from DBUserLoginSettings))
		begin
			update DBUserLoginSettings set idle_time=
				@idle_time where idle_time=(select top (1) idle_time from DBUserLoginSettings)				
		end
	else
		begin
			insert into DBUserLoginSettings values (@idle_time)
		end
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertDBUserLoginUsers]    Script Date: 07/14/2016 18:32:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertDBUserLoginUsers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertDBUserLoginUsers]
	@surname NVARCHAR(50),
	@name NVARCHAR(50),
	@secondname NVARCHAR(50),
	@workstart NVARCHAR(50),
	@workend NVARCHAR(50),
	@username1 NVARCHAR(50),
	@computername nvarchar(50)
AS
BEGIN
	insert into DBUserLoginUsers
		(surname, 
		name, 
		secondname, 
		workstart, 
		workend, 
		username1,
		usercomputer) 
	values 
		(@surname, 
		@name, 
		@secondname, 
		@workstart, 
		@workend, 
		@username1,
		@computername)
END
' 
END
GO
