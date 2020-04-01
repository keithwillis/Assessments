using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CreateUserProfile
{
    public static bool BeforeCreate(string email)
    {
        /*   List<Profile> profiles = SocialMediaProfiles.FetchSocialProfiles(email);
           SaveResult result = null;

           try
           {
               result = SocialMediaProfiles.SaveProfiles(profiles);
           }
           catch (Exception ex)
           {
               System.Console.WriteLine(ex.Message);
           }

           return result.Success;*/
        return true;
    }
}