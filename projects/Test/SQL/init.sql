CREATE TABLE TEST.SYS_PROJECT 
(	
	ID integer primary key, 
	PROJECTNO VARCHAR2(100), 
	PROJECTNAME VARCHAR2(200), 
	ENDTIME DATE, 
	BUILDADRESS VARCHAR2(500), 
	CREATETIME DATE, 
	ISDELETE NUMBER(1,0), 
	REF_BUSINESS_ID NUMBER,
	PID NUMBER
);


CREATE TABLE TEST.SYS_PROJECTFORM 
(	
	ID integer primary key, 
	FORMNAME VARCHAR2(50), 
	DESCRIPTION VARCHAR2(256), 
	REF_BUSINESSFORM_ID NUMBER,
	REF_PROJECT_ID NUMBER,
	CREATETIME DATE
);

CREATE TABLE TEST.SYS_PROJECTMATERIAL 
(	
	ID integer primary key, 
	MATERIALNAME VARCHAR2(250), 
	REF_BUSINESSMATERIAL_ID VARCHAR2(250), 
	REF_PROJECT_ID VARCHAR2(20), 
	FILEPATH VARCHAR2(256), 
	FILESIZE NUMBER, 
	CREATETIME DATE, 
	CREATEUSER VARCHAR2(20), 
	DESCRIPTION VARCHAR2(500)
);


CREATE TABLE SYS_BUSINESSMATERIAL 
(	
	ID integer primary key, 
	MATERIALNAME VARCHAR2(250), 
	REF_BUSINESS_ID VARCHAR2(20), 
	CREATETIME DATE, 
	DESCRIPTION VARCHAR2(500)
);

create table sys_business
(
	id integer primary key,
	BUSINESSNAME varchar2(100),
	SHORTNAME varchar2(50),       
	createtime date,
	description varchar2(200)
);

create table sys_businessprocess
(
	id integer primary key,
	PROCESSNAME varchar2(200),
	ref_business_id integer,
	createtime date
);


create table sys_businessactivity
(
	id integer primary key,
	ACTIVITYNAME VARCHAR2(200),
	REF_BUSINESS_ID INTEGER,
	REF_BUSINESSPROCESS_ID INTEGER
);
       

create table sys_projectprocess
(
	id integer primary key,
	ref_BUSINESSPROCESS_id integer,
	ref_user_id integer,
	createtime date
);

create table sys_projectactivity
(
    id integer primary key,
	ref_projectprocess_id integer,
    ref_businessactivity_id integer,
    ref_user_id integer,
    starttime date,
    endtime date
);

create table sys_user
(
    id integer primary key,
    username varchar2(100),
    password varchar2(100),
    createtime date,
    state number(1,0)
);

