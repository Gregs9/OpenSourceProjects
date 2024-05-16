WELCOME TO THE PUBLIC VERSION OF THE GARNET, A HOBBY AND LEARNING PROJECT FOR PHP, JAVASCRIPT AND JQUERY.

Please note that this website may be severly vulnurable to attacks. Never use any real data when submitting information on this website.

Check out the about page to learn more.

As of now, session hashing is hardcoded in the api, and should be generated for each user in the database instead. However for simplicity's sake I did not yet implement this.
Additionally, not all sensitive actions even use session hashing right now, like deleting, blocking or promoting/demoting users. I will need to change this in the furute.

