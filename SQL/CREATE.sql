CREATE TABLE tblUsers
(
	ID	int		not null	identity(1,1),
	UserName	nvarchar(20)	not null,
	[Password]	nvarchar(20)	not null,
	Email		nvarchar(64)	not null,
	RegistrationDate	datetime not null DEFAULT CURRENT_TIMESTAMP,

	CONSTRAINT pk_tblUsers_ID PRIMARY KEY (ID)
)

CREATE TABLE tblArticles
(
	ID	int		not null	identity(1,1),
	Header	nvarchar(1024)	not null,
	Content nvarchar(MAX)	not null,
	UserID	int	not null,
	[Date]	datetime not null	DEFAULT CURRENT_TIMESTAMP,

	CONSTRAINT pk_tblArticles_ID PRIMARY KEY (ID),
	CONSTRAINT fk_tblArticles_UserID_tblUsers_ID 
		foreign key (UserID)
		references tblUsers(ID)
)

CREATE TABLE tblComments
(
	ID	int	not null	identity(1,1),
	UserID	int	not null,
	ArticleID	int	not null,
	Comment	nvarchar(2048)	not null,
	[Date]	datetime not null DEFAULT CURRENT_TIMESTAMP,

	CONSTRAINT pk_tblComments_ID PRIMARY KEY(ID),

	CONSTRAINT fk_tblComments_UserID_tblUsers_ID
		foreign key (UserID)
		references	tblUsers(ID),

	CONSTRAINT fk_tblComments_ArticleID_tblArticles_ID
		foreign key (ArticleID)
		references	tblArticles(ID)
)

CREATE TABLE tblTags
(
	ID int not null identity(1,1),
	Name nvarchar(32) not null,
	TagRequest int not null default 0,

	CONSTRAINT pk_tblTags_ID PRIMARY KEY(ID)
)

CREATE TABLE tblArticlesTags
(
	ID int not null	identity(1,1),
	ArticleID	int not null,
	TagID	int not null,

	CONSTRAINT pk_tblArticlesTags_ID PRIMARY KEY (ID),

	CONSTRAINT fk_tblArticlesTags_ArticleID_tblArticles_ID
	FOREIGN KEY (ArticleID) REFERENCES tblArticles(ID),

	CONSTRAINT fk_tblArticlesTags_TagID_tbTags_ID
	FOREIGN KEY (TagID) REFERENCES tblTags(ID),

	CONSTRAINT uq_tblArticlesTags_ArticleID_TagID UNIQUE(ArticleID, TagID)
)
