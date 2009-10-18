// Learn more about F# at http://fsharp.net
open System
open Solve

let payments plan d c =
    let back =
        plan
        |> Seq.mapi (fun i s ->
            let i = float i
            let c = Math.Pow(c, 1.0 + i)
            let d = Math.Pow(d, 1.0 + i)
            d * c * s)
        |> Seq.sum
    -1.0 + back

let convertAnnualToMonthly C =
    Math.Pow(1.0 - C, 1.0/12.0)

let computeMonthlyRisk D =
    let f x =
        x * (1.0 - Math.Pow(x, 12.0)) / (1.0 - x) - 12.0 * (1.0 - D)
    solve 1.0e-15 f 0.001 0.999
    
let solveInterest repayment N D C g =
    let c = convertAnnualToMonthly C
    let d = computeMonthlyRisk D
    let plan x = repayment N 1.0 x
    let payments x = payments (plan x) d c 
    let f x =
        (payments x) - g
    
    let result = Solve.solve 0.001 f 0.0 10.0
    result

let formatPerCent x =
    Math.Ceiling(x * 10000.0) / 100.0

let durations = [6;12;15;18;24]

let compCountry repayment country D C =
    let solveInterest = solveInterest repayment
    printfn "%s:" country
    printfn "\tGoal\t6\t12\t15\t18\t24"
    for goal in [0.0; 0.03; 0.04] do
        let values_string =
            durations
            |> List.map (fun N -> solveInterest N D C goal |> formatPerCent)
            |> List.map (sprintf "%2.1f")
            |> Array.of_list
            |> fun s -> System.String.Join("\t", s)
                    
        printfn "\t%2.1f\t%s" (formatPerCent goal) values_string
    
    let c = convertAnnualToMonthly C
    let d = computeMonthlyRisk D
    let losses =
        durations
        |> Seq.map (fun N -> payments (repayment N 1.0 0.0) d c)
        |> Seq.map formatPerCent
        |> Seq.map (sprintf "%2.1f")
        |> Array.of_seq
        |> fun s -> System.String.Join("\t", s)
    
    printfn "\tLosses:\t%s" losses
