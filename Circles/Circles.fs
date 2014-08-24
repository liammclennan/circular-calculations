module Circles

open System

// find n evenly spaced points on a circle of radius r
// step 1: calculate the angle of each points
// step 2: the x coordinate will be the cosine of the angle * the radius of the circle
//         the y coordinate will be the sine of the angle * the radius of the circle
// more info: http://www.montereyinstitute.org/courses/DevelopmentalMath/COURSE_TEXT2_RESOURCE/U19_L2_T2_text_final.html
//            http://www.purplemath.com/modules/triggrph.htm  
let points n r : (float * float) list =
    []

// find the set of intervals between a set of points on a circle
// step 1: for each pair of adjacent points calculate the euclidean distance between the points ie. sqrt((difference in x values)^2 + (difference in y values)^2))
// step 2: realise that the intervals are all the same (by definition), therefore the calculation only needs to be done once
// more info: http://en.wikipedia.org/wiki/Euclidean_distance
let intervals ps : float list =
    []

// find the sum of the intervals between a set of points on a circle
let intervalDistance ps : float = 
    0.0

// find the ratio (sum of intervals between a set of points on a circle) : (the diameter of the circle)
// ie. (sum of intervals between adjacent points) / radius * 2
let ratio r ps : float = 
    0.0
