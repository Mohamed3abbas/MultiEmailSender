# MultiEmailSender
This Program Can Sending Emails for Multi Users
Email Sender Project Documentation
1.	EmailMessage Model: This model represents an email message and contains the following properties:
    •	Id: A unique identifier for the email message.
    •	Subject: The subject line of the email.
    •	Message: The body of the email message.
2.	IGenericRepository<T> Interface: This interface defines the basic Needed operations that can be performed on any type of entity. In this project, it is used to define a repository for the EmailMessage model.
3.	GenericRepository<T> Class: This class implements the IGenericRepository<T> interface and provides a generic implementation of the basic CRUD operations.
4.	IMailingServices Interface: This interface defines a method for sending an email message to one or more recipients.
5.	MailingServices Class: This class implements the IMailingServices interface and provides a concrete implementation of the SendEmailAsync method using the SmtpClient class.
6.	EmailSender Controller: This is the main controller for the project and contains the following actions:
    •	Create: This action displays a form to create a new email message and saves the message to the database.
    •	SendingEmails: This action displays a form to send an email message to one or more recipients.
    •	SuccessfullySent: This action displays a confirmation page after an email message has been successfully sent.
7.	Create.cshtml View: This view contains a form to create a new email message and includes fields for the subject and message.
8.	SendingEmails.cshtml View: This view contains a form to send an email message to one or more recipients and includes fields for the subject, recipients, and message.
9.	SuccessfullySent.cshtml View: This view displays a confirmation message after an email message has been successfully sent.

To use the email sender project, follow these steps:
    1.	First You Have To Make Migration And Update database
    2.	Create a new email message by navigating to the "Create" page and filling out the form with a subject and message.
    3.	
    4.	Send an email message by navigating to the "SendingEmails" page and filling out the form with a subject, one or more recipients, and a message.
    5.	Confirm that the email message was sent successfully by navigating to the "SuccessfullySent" page.

