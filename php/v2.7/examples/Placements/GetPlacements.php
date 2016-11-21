<?php
/*
 * Copyright 2015 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

// Require the base class.
require_once dirname(__DIR__) . '/BaseExample.php';

/**
 * This example displays all available placements.
 */
class GetPlacements extends BaseExample {
  /**
   * (non-PHPdoc)
   * @see BaseExample::getInputParameters()
   * @return array
   */
  protected function getInputParameters() {
    return array(
        array('name' => 'user_profile_id',
              'display' => 'User Profile ID',
              'required' => true)
    );
  }

  /**
   * (non-PHPdoc)
   * @see BaseExample::run()
   */
  public function run() {
    $values = $this->formValues;

    print '<h2>Listing all placements</h2>';

    $response = null;
    $pageToken = null;

    $this->printResultsTableHeader('Placements');

    do {
      // Create and execute the placements list request.
      $response = $this->service->placements->listPlacements(
          $values['user_profile_id'],
          array('pageToken' => $pageToken)
      );

      foreach ($response->getPlacements() as $placements) {
        $this->printResultsTableRow($placements);
      }

      // Update the next page token.
      $pageToken = $response->getNextPageToken();
    } while(!empty($response->getPlacements()) && !empty($pageToken));

    $this->printResultsTableFooter();
  }

  /**
   * (non-PHPdoc)
   * @see BaseExample::getName()
   * @return string
   */
  public function getName() {
    return 'Get All Placements';
  }

  /**
   * (non-PHPdoc)
   * @see BaseExample::getResultsTableHeaders()
   * @return array
   */
  public function getResultsTableHeaders() {
    return array(
        'id' => 'Placement ID',
        'name' => 'Placement Name',
        'campaignId' => 'Associated Campaign ID'
    );
  }
}
