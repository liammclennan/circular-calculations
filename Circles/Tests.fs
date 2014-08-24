module Tests

open System
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``when generating 2 points on a circle of radius 10`` () =
    let points = Circles.points 2 10
    
    [<Test>]
    member t.``the first point is (10,0)`` ()=
        points.Head |> should equal (10.0,0.0)

    [<Test>]
    member t.``the second point is (-10,0)`` ()=
        points.Item(1) |> should equal (-10.0,0.0)
        

[<TestFixture>]
type ``when generating 2000 points on a circle of radius 100`` () =
    let points = Circles.points 2000 100
    
    [<Test>]
    member t.``the first point is (100,0)`` ()=
        points.Head |> should equal (100.0,0.0)

    [<Test>]
    member t.``there are 2000 points`` ()=
        List.length points |> should equal 2000
        
[<TestFixture>]
type ``finding the distance between 2 points on a circle of radius 10`` () =
    let points = Circles.points 2 10
    let intervals = Circles.intervals points
    
    [<Test>]
    member t.``there should be 2 intervals`` ()=
        List.length intervals |> should equal 2
       
    [<Test>]
    member t.``both intervals should be 20`` ()=
        List.forall (fun i -> i = 20.0) intervals |> should equal true


[<TestFixture>]
type ``finding the distance between 4 points on a circle of radius 10`` () =
    let points = Circles.points 4 10
    let intervals = Circles.intervals points
    
    [<Test>]
    member t.``there should be 4 intervals`` ()=
        List.length intervals |> should equal 4
       
    [<Test>]
    member t.``all intervals should be 20`` ()=
        List.forall (fun i -> i = sqrt 200.0) intervals |> should equal true

[<TestFixture>]
type ``when suming the intervals between points 4 points on a circle of radius 10`` ()=
    let points = Circles.points 4 10

    [<Test>]
    member t.``the sum should be sqrt 200 * 4`` ()=
        Circles.intervalDistance points |> should equal (sqrt 200.0 |> (*) 4.0)

[<TestFixture>]
type ``when calculating the ration between the sum of intervals and diameter of a circle`` ()=
    let setsOfPoints = List.map (fun n -> Circles.points n 100000000) [10;20;30;50;70;100;150;200;2000;20000]
    let ratios = List.map (Circles.ratio 100000000.0) setsOfPoints

    [<Test>]
    member t.``the ratios approach pi`` ()=
        let folder d r =
            let diff = abs (Math.PI - r)
            diff |> should be (lessThan d)            
            diff

        List.fold folder 1.0 ratios |> ignore
        ()