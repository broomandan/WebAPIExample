'use strict';

/* Controllers */

function PuzzleResultCtrl($scope,$http) {
  $scope.puzzleResultSteps ={};
  $scope.load = function() {
    if($scope.sourceBucket && $scope.targetBucket && $scope.goal){
      console.log('inside load');
      //api/lakePuzzleResult/3/5/4
      $http.get('/api/lakePuzzleResult/'+ $scope.sourceBucket + '/' + $scope.targetBucket  + '/' + $scope.goal ).
      success(function(data) {
        $scope.puzzleResultSteps = data;
        console.log('success');
      }).
      error(function(data, status, headers, config) {
        console.log('failed');
        $scope.puzzleResultSteps = [
          {"SourceBucketOperation":"Failed","SourceBucketState":0,"TargetBucketOperation":"E","TargetBucketState":0}
        ];  
      });
    }
  }
}

  /*[
    {"SourceBucketOperation":"E","SourceBucketState":0,"TargetBucketOperation":"E","TargetBucketState":0},
    {"SourceBucketOperation":"F","SourceBucketState":5,"TargetBucketOperation":" ","TargetBucketState":0},
    {"SourceBucketOperation":"T","SourceBucketState":2,"TargetBucketOperation":"T","TargetBucketState":3},
    {"SourceBucketOperation":" ","SourceBucketState":2,"TargetBucketOperation":"E","TargetBucketState":0},
    {"SourceBucketOperation":"T","SourceBucketState":0,"TargetBucketOperation":"T","TargetBucketState":2},
    {"SourceBucketOperation":"F","SourceBucketState":5,"TargetBucketOperation":" ","TargetBucketState":2},
    {"SourceBucketOperation":"T","SourceBucketState":4,"TargetBucketOperation":"T","TargetBucketState":3}
  ];*/


 