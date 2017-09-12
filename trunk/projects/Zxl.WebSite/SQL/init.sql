create sequence seq_SYS_SYSTEMCONFIG;
create table SYS_SYSTEMCONFIG
(
	ID integer primary key, 
	KEY VARCHAR2(100), 
	VALUE VARCHAR2(200),
	DESCRIPTION VARCHAR2(200)
);

create sequence seq_SYS_PROJECT;
CREATE TABLE SYS_PROJECT 
(	
	ID integer primary key, 
	PROJECTNO VARCHAR2(100), 
	PROJECTNAME VARCHAR2(200), 
	ENDTIME DATE, 
	BUILDORG VARCHAR2(200), 
	BUILDADRESS VARCHAR2(500), 
	CREATETIME DATE, 
	ISDELETE NUMBER(1,0), 
	REF_BUSINESS_ID NUMBER,
	PID NUMBER
);

create sequence SEQ_SYS_PROJECTFORM;
CREATE TABLE SYS_PROJECTFORM 
(	
	ID integer primary key, 
	FORMNAME VARCHAR2(50), 
	DESCRIPTION VARCHAR2(256), 
	REF_BUSINESSFORM_ID NUMBER,
	REF_PROJECT_ID NUMBER,
	CREATETIME DATE
);

create sequence seq_SYS_PROJECTMATERIAL;
CREATE TABLE SYS_PROJECTMATERIAL 
(	
	ID integer primary key, 
	MATERIALNAME VARCHAR2(250), 
	REF_BUSINESSMATERIAL_ID VARCHAR2(250), 
	REF_PROJECT_ID VARCHAR2(20), 
	FILEPATH VARCHAR2(256), 
	FILESIZE VARCHAR2(20), 
	CREATETIME DATE, 
	CREATEUSER VARCHAR2(20), 
	DESCRIPTION VARCHAR2(500)
);

CREATE TABLE SYS_BUSINESSFORM
(  
	ID integer primary key, 
	FORMNAME VARCHAR2(250), 
	REF_BUSINESS_ID VARCHAR2(20), 
	CONTENT blob,
	CREATETIME DATE, 
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

create sequence seq_sys_projectactivity;
create table sys_businessactivity
(
	id integer primary key,
	ACTIVITYNAME VARCHAR2(200),
	REF_BUSINESS_ID INTEGER,
	REF_BUSINESSPROCESS_ID INTEGER,
	ref_businessrole_id integer
);

--����ģ��·��
create table SYS_BUSINESSACTIVITYROUTE
(
       ID integer primary key, 
       REF_FROM_BUSINESSACTIVITY_ID integer,
       REF_TO_BUSINESSACTIVITY_ID integer
);
       
create sequence seq_SYS_PROJECTPROCESS;
create table sys_projectprocess
(
	id integer primary key,
	ref_project_id integer,
	ref_BUSINESSPROCESS_id integer,
	ref_user_id integer,
	createtime date
);

create sequence seq_SYS_PROJECTACTIVITY;
create table sys_projectactivity
(
    id integer primary key,
	ref_project_id integer,
	ref_projectprocess_id integer,
    ref_businessactivity_id integer,
    --ref_user_id integer,
	state integer default 0 --0Ϊ�ڰ죬1Ϊ�Ѱ�
    --starttime date,
    --endtime date
);

create sequence SEQ_SYS_PROJECTWORKITEM; 
create table SYS_PROJECTWORKITEM
(
    id integer primary key,
	ref_project_id integer,
    REF_PROJECTACTIVITY_ID integer,
    ref_user_id integer,
	state integer default 0, --0Ϊ�ڰ죬1Ϊ�Ѱ�
    starttime date,
    endtime date
);

--����ʵ��·��
create sequence SEQ_SYS_PROJECTACTIVITYROUTE;
create table SYS_PROJECTACTIVITYROUTE
(
       ID integer primary key, 
       REF_FROM_PROACT_ID integer,
       REF_TO_PROACT_ID integer
);

create table sys_user
(
    id integer primary key,
    username varchar2(100),
    password varchar2(100),
	USERIMG varchar2(100),
	DEPARTMENT varchar2(100),
	ROLE varchar2(100),
	MOBILE varchar2(100),
	PHONE varchar2(100),
	EMAIL varchar2(100),
    createtime date,
    state number(1,0)
);

create table sys_businessrole
(
    id integer primary key,
    rolename varchar2(100),
    ref_business_id integer,
    createtime date
);

create table sys_businessroleuser
(
    id integer primary key,
    ref_user_id integer,
    ref_businessrole_id integer
);

--������
create sequence SEQ_SYS_ARCHIVE;
create table sys_archive
(
	ID integer primary key, 
	REF_PROJECT_ID NUMBER,
	PROJECTNO VARCHAR2(100), 
	PROJECTNAME VARCHAR2(200),
	BUILDORG VARCHAR2(200), 
	BUILDADRESS VARCHAR2(500), 
	ARCHIVENO  VARCHAR2(100), 
	ARCHIVETIME DATE
);

--��Ϣ��
create sequence SEQ_SYS_MESSAGE;
CREATE TABLE SYS_MESSAGE 
(  
	ID integer primary key, 
	TYPE NUMBER, 
	REF_PROJECT_ID NUMBER,
	INSPARAMS VARCHAR2(500), 
	SENDUSERID NUMBER, 
	SENDDATE DATE DEFAULT NULL, 
	RECVUSERID NUMBER, 
	RECVDATE DATE, 
	RECVSTATE NUMBER DEFAULT 0, 
	SHOWRECV NUMBER DEFAULT 0, 
	CONTENT VARCHAR2(2000),
	STATE NUMBER default 0
);
COMMENT ON COLUMN SYS_MESSAGE.ID IS '�ؼ�ֵ'; 
COMMENT ON COLUMN SYS_MESSAGE.TYPE IS '���'; 
COMMENT ON COLUMN SYS_MESSAGE.REF_PROJECT_ID IS '��Ӧʵ��ID'; 
COMMENT ON COLUMN SYS_MESSAGE.INSPARAMS IS '��Ӧʵ�����Ӳ���'; 
COMMENT ON COLUMN SYS_MESSAGE.SENDUSERID IS '������'; 
COMMENT ON COLUMN SYS_MESSAGE.SENDDATE IS '����ʱ��'; 
COMMENT ON COLUMN SYS_MESSAGE.RECVUSERID IS '������'; 
COMMENT ON COLUMN SYS_MESSAGE.RECVDATE IS '����ʱ��'; 
COMMENT ON COLUMN SYS_MESSAGE.RECVSTATE IS '0δ����1�ѽ���'; 
COMMENT ON COLUMN SYS_MESSAGE.SHOWRECV IS '��ʾ������(0��1��)'; 
COMMENT ON COLUMN SYS_MESSAGE.CONTENT IS '��Ϣ����';
COMMENT ON COLUMN SYS_MESSAGE.STATE IS '״̬';








--���ƶ�
--Ԫ����
create sequence SEQ_SYS_METADATA;
create table SYS_METADATA
(
       ID number primary key,
       NAME varchar2(200),
       DESCRIPTION varchar2(200),
       LAYOUT blob
);

--Ԫ�����ֶ�
create sequence SEQ_SYS_METADATADETAIL;
create table SYS_METADATADETAIL
(
       id number primary key,
       ref_metadata_id number,
       name varchar2(200),
       description varchar2(200),
       datatype varchar2(50),
       length number,
	   nullable number,
	   defaultval varchar2(500)
);