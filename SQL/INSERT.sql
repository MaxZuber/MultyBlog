INSERT INTO tblUsers (UserName, [Password], [Email]) 
Values ('max', 'max', 'zuber.max.v@gmail.com') ;

select * from tblUsers

INSERT INTO tblArticles(Header, Content, UserId)
values('Article on IOS Programming', 'OS Programming For Beginners
I need a 4,000 word article on iOS Programming For Beginners. Describe basic principles on how iOS programming works and how to create apps iOS apps. Give some iOS programming examples. Also do an introduction and conclusion sections - make them short (about 2 paragraphs for each section). Be specific , no fluff. Divide the article into different sections with subtitles. Dont use any fancy text formatting (such as colors other than black) besides bold text and subtitles, dont use Microsoft Word bullets and numbering feature - for numbering just use plain text numbers like 1,2,3 etc. or letters like a), b), c) etc. or you can also use dashes. Dont do different text alignments - align text in only one way through the whole article. Use font Calibri (Body). In the article itself dont refer and dont quote any websites or public figures.
Special Note - make sure that the article is unique and can pass a Copyscape check. I strongly advocate to check the article for uniqueness with Copyscape (it will speed up article approval process), because other tools might be less accurate and might not show duplicate results when Copyscape will do. Keep in mind that I need the article to be able to pass a Copyscape check (while I dont care about the article passing other plagiarism checking tools). When using Copyscape make sure that you check the article by small parts (no more than 400-500 words at once).', 1);

INSERT INTO tblArticles(Header, Content, UserId)
values('Need good writers: Newbies are also welcome', 'Hello

I need 2 good writers who can write in good English and can provide me original and informative content. Quality and ability to meet deadlines is very important. The work is in bulk and for long term. I will pay 1$ inclusive of oDesk fees for 500 words. Only apply if you agree at this rate. The selected candidate must be able to take the pressure of tight deadlines.

I will pay weekly and its a good opportunity for those who are good writers, but are new here and looking for an opportunity to start. I need to start this project urgently so please bid only if you want to start asap. I will also want you to first write a sample for me so that I may get an idea about your writing skills. I do not have the time to teach you how to write so you must have experience of writing contents and should be well versed with the basic things.

Please write I agree at the top of the cover letter to let me know that you have read full post...no later arguments over rate or other terms.

Availability on Skype or Hangouts or Whatsapp is a must.
No Upfronts Please!
Weekly Payments!!

Happy Bidding!!!', 1);

select * from tblArticles

INSERT INTO tblComments ([UserID],[ArticleID], Comment) values
 (1, 1, 'Nice Article'),
 (1, 1, 'Good'),
 (1, 1, 'third comment'),
 (1, 1, 'More comments');

 select * from tblComments;

 INSERT INTO tblTags(Name, TagRequest) values
 ('sport', 1),
 ('life', 2),
 ('asp.net', 3),
 ('mvc', 4),
 ('C#', 5),
 ('ios', 6),
 ('android', 5),
 ('computer', 4),
 ('electronic', 3);

go

INSERT INTO tblArticlesTags (ArticleID, TagID) values
(1, 6),
(1, 5),
(1, 8),
(1, 9),
(2, 1),
(2, 2),
(2, 3);

go

select * from tblTags;