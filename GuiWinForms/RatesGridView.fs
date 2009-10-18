open System.Windows.Forms
open InterestFinder


let setRowBreakEven repayment D C (row : DataGridViewRow) =
    let solveInterest = solveInterest repayment

    row.Cells.[0].Value <- box "0% loss"

    let goal = 0.0
    let values =
        durations
        |> List.map (fun N -> solveInterest N D C goal |> formatPerCent)

    values
    |> Seq.iteri (fun i v ->
        row.Cells.[1+i].Value <- box v)


let setRowLoss repayment D C (row : DataGridViewRow) =
    row.Cells.[0].Value <- box "Loss at 0%"
    
    let c = convertAnnualToMonthly C
    let d = computeMonthlyRisk D
    let losses =
        durations
        |> Seq.map (fun N -> payments (repayment N 1.0 0.0) d c)
        |> Seq.map formatPerCent

    losses
    |> Seq.iteri (fun i v ->
        row.Cells.[1+i].Value <- box v)


let setLossAndBreakEvent pos D C (view : DataGridView) =
    setRowBreakEven Repayment.constant D C (view.Rows.[pos])
    setRowLoss Repayment.constant D C (view.Rows.[pos+1])


let addCountry label D C (view : DataGridView) =
    let addRowRO label = 
        let pos = view.Rows.Add(1)
        view.Rows.[pos].Cells.[0].Value <- box label
        view.Rows.[pos].ReadOnly <- true
        pos

    let pos = addRowRO label
    addRowRO "..." |> ignore
    addRowRO "..." |> ignore
    
    setLossAndBreakEvent (pos + 1) D C view 
    pos
    
    
let newGridView () =
    let view = new DataGridView()
    view.ColumnCount <- 6
    view.Columns.[0].Name <- ""
    view.Columns.[1].Name <- "6 months"
    view.Columns.[2].Name <- "12 months"
    view.Columns.[3].Name <- "15 months"
    view.Columns.[4].Name <- "18 months"
    view.Columns.[5].Name <- "24 months"
    view.Dock <- DockStyle.Fill
    view.AllowUserToAddRows <- false
    view
