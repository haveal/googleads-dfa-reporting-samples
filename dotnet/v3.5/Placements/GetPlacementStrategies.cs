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
using System.Linq;
using Google.Apis.Dfareporting.v3_5;
using Google.Apis.Dfareporting.v3_5.Data;

namespace DfaReporting.Samples {
  /// <summary>
  /// This example displays all available placement strategies.
  /// </summary>
  class GetPlacementStrategies : SampleBase {
    /// <summary>
    /// Returns a description about the code example.
    /// </summary>
    public override string Description {
      get {
        return "This example displays all available placement strategies.\n";
      }
    }

    /// <summary>
    /// Main method, to run this code example as a standalone application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void Main(string[] args) {
      SampleBase codeExample = new GetPlacementStrategies();
      Console.WriteLine(codeExample.Description);
      codeExample.Run(DfaReportingFactory.getInstance());
    }

    /// <summary>
    /// Run the code example.
    /// </summary>
    /// <param name="service">An initialized Dfa Reporting service object
    /// </param>
    public override void Run(DfareportingService service) {
      long profileId = long.Parse(_T("INSERT_USER_PROFILE_ID_HERE"));

      // Limit the fields returned.
      String fields = "nextPageToken,placementStrategies(id,name)";

      PlacementStrategiesListResponse strategies;
      String nextPageToken = null;

      do {
        // Create and execute the placement strategies list request
        PlacementStrategiesResource.ListRequest request =
            service.PlacementStrategies.List(profileId);
        request.Fields = fields;
        request.PageToken = nextPageToken;
        strategies = request.Execute();

        foreach (PlacementStrategy strategy in strategies.PlacementStrategies) {
          Console.WriteLine("Found placement strategy with ID {0} and name \"{1}\".",
              strategy.Id, strategy.Name);
        }

        // Update the next page token
        nextPageToken = strategies.NextPageToken;
      } while (strategies.PlacementStrategies.Any() && !String.IsNullOrEmpty(nextPageToken));
    }
  }
}
