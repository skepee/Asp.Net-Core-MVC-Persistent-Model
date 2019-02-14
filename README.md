# PersistentModel
Databaseless and sessionless example of persistent model in .Net Core MVC application


Consider, for example, a generic filling form application where data are requested to be filled (mandatory or not) in n steps. Take also in consideration that after posting your form at n-step, data at (n-1)-step are not available anymore. Practically data filled at (n-1)-step should be avalailable at the n-step. In this way at the and of the filling process you will have all the information requested from the first to the last step step.

Normally, one of the solutions is to save data in database at each step and retrieve again them in the next step and so on. Is this the best approach? How to do that if you want to reduce at minimum interactions with database (obviously only at the beginning and finalizing it)?

Another approach is to use session variables. You could store data in session valiables at each step so that the mechanism we are looking for can be easily overcome. Probably I am reluctant to use session variables unless I really need them, so I excluded it. Do we have alternatives?

Thinking, thinking, thinking... I created this mechanism by using the MVC architecture by using Asp.Net Core MVC, without database and no session variables.


# What's the idea?
Tha basic idea is to use a static class to store data from your form (at each step). This class is the same type of your model. Once  your model has been created, in the `helper` class you need to set properly the `sync()` static method.
For example, if `MyModel` is your model, 

``` 
  public static class Helper
    {
        private static MyModel MyModelInController { get; set; }

        public static MyModel Sync(this MyModel myModel)
        {
            // ..................................
            // update your MyModelInController
            // ..................................
            
            return MyModelInController;
        }
    }
```

After that, it's enough to call `model.Sync()` when returning your View, like this:

`return View("YourView", model.Sync());`
