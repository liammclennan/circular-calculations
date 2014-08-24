module Circles

open System

let private degreesToRadians (d:float) : float =
    d * (Math.PI / 180.0)

// a cosine function for degrees
let private dCos = degreesToRadians >> cos

// a sine function for degrees
let private dSin = degreesToRadians >> sin

// find the point where the terminal side of the angle in standard position crosses the circle
let private angleToPoint (r:float) (a:float) : float * float =
    let roundTo4Places (f:float) = Math.Round(f, 4)
    let angleToX = dCos >> (*) r >> roundTo4Places
    let angleToY = dSin >> (*) r >> roundTo4Places
    (angleToX a, angleToY a)

// find the distance between 2 points
let private euclideanDistance (x1,y1) (x2,y2) =
    (x2 - x1) ** 2.0 + (y2 - y1) ** 2.0 |> sqrt

// find n evenly spaced points on a circle of radius r
let points n r : (float * float) list =
    let degreesInCircle = 360.0
    let degreesBetweenPoints = degreesInCircle / float n
    let angles = List.map (fun i -> float i * degreesBetweenPoints) [0..n-1]
    List.map (angleToPoint (float r)) angles

// find the set of intervals between a set of points on a circle
let intervals ps : float list =
    List.replicate (List.length ps) (euclideanDistance (List.head ps) (ps.Item(1)))

// find the sum of the intervals between a set of points on a circle
let intervalDistance ps : float = 
    intervals ps |> List.sum

// find the ratio (sum of intervals between a set of points on a circle) : (the diameter of the circle)
let ratio r ps = 
    intervalDistance ps / (2.0 * r)
