﻿/*
 * Copyright 2015 Google Inc
 *
 * Licensed under the Apache License, Version 2.0(the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using Google.Apis.Dfareporting.v3_5;
using Google.Apis.Dfareporting.v3_5.Data;

namespace DfaReporting.Samples {
  /// <summary>
  /// This example illustrates how to get a list of all user profiles.
  /// </summary>
  class GetUserProfiles : SampleBase {
    /// <summary>
    /// Returns a description about the code example.
    /// </summary>
    public override string Description {
      get {
        return "This example illustrates how to get a list of all user profiles.\n";
      }
    }

    /// <summary>
    /// Main method, to run this code example as a standalone application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void Main(string[] args) {
      SampleBase codeExample = new GetUserProfiles();
      Console.WriteLine(codeExample.Description);
      codeExample.Run(DfaReportingFactory.getInstance());
    }

    /// <summary>
    /// Run the code example.
    /// </summary>
    /// <param name="service">An initialized Dfa Reporting service object
    /// </param>
    public override void Run(DfareportingService service) {
      // Retrieve and print all user profiles for the current authorized user.
      UserProfileList profiles = service.UserProfiles.List().Execute();
      foreach (UserProfile profile in profiles.Items) {
        Console.WriteLine("User profile with ID {0} and name \"{1}\" was found for account {2}.",
                    profile.ProfileId, profile.UserName, profile.AccountId);
      }
    }
  }
}
