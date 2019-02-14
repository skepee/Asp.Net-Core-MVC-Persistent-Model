# PersistentModel
Databaseless and sessionless example of persistent model in .Net Core MVC application


Consider, for example, a generic filling form application where data are requested to be filled (mandatory or not) in n steps. Take also in consideration that after posting your form at n-step you do not have anymore data at (n-1)-step. Practically data filled at (n-1)-step should be avalailable at the n-step. In this way at the and of the filling process you will have all the information requested from 1 to n step.

Normally, one of the solutions is to save data in database at each step and retrieve again them in the next step and so on. Is this the best approach? How to do that if you want to reduce at minimum interactions with database (obviously only at the beginning and finalizing it)?

Another approach is to use session variables. You could store data in session valiables at each step so that the mechanism we are looking for can be easily overcome. Probably I am reluctant to use session variables unless I really need them. Do we have an alternative?

Thinking, thinking, thinking... I created this mechanism by using the MVC architecture by using Asp.Net Core MVC, without database and no session variables. Enjoy!
