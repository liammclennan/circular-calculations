module Circles

open System

let private degreesToRadians d =
    d * (Math.PI / 180.0)

let private dCos = degreesToRadians >> cos

let private dSin = degreesToRadians >> sin

let roundTo4Places (f:float) = Math.Round(f, 4)

let private angleToPoint (r:float) (a:float) : float * float =
    let angleToX = dCos >> (*) r >> roundTo4Places
    let angleToY = dSin >> (*) r >> roundTo4Places
    (angleToX a, angleToY a)

let points n r : (float * float) list =
    let degreesInCircle = 360.0
    let degreesBetweenPoints = degreesInCircle / float n
    let angles = List.map (fun i -> float i * degreesBetweenPoints) [0..n-1]
    List.map (angleToPoint (float r)) angles

let euclideanDistance (x1,y1) (x2,y2) =
    (x2 - x1) ** 2.0 + (y2 - y1) ** 2.0 |> sqrt

let intervals ps : float list =
    List.replicate (List.length ps) (euclideanDistance (List.head ps) (ps.Item(1)))

let intervalDistance ps : float = 
    intervals ps |> List.sum

let ratio r ps = 
    intervalDistance ps / (2.0 * r)