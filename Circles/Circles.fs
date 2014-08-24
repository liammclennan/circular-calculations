module Circles

open System

// find n evenly spaced points on a circle of radius r
// step 1: calculate the angle of each points
// step 2: the x coordinate will be the cosine of the angle * the radius of the circle
//         the y coordinate will be the sine of the angle * the radius of the circle
let points n r : (float * float) list =
    []

// find the set of intervals between a set of points on a circle
// step 1: for each pair of adjacent points calculate the euclidean distance between the points ie. sqrt((difference in x values)^2 + (difference in y values)^2))
// step 2: realise that the intervals are all the same (by definition), therefore the calculation only needs to be done once
let intervals ps : float list =
    []

// find the sum of the intervals between a set of points on a circle
let intervalDistance ps : float = 
    0.0

// find the ratio (sum of intervals between a set of points on a circle) : (the diameter of the circle)
let ratio r ps : float = 
    0.0
