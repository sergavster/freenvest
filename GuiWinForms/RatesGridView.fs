open System.Windows.Forms
open InterestFinder


let newGridView label =
    let view = new DataGridView()
    view.ColumnCount <- 1 + Array.length durations
    view.Columns.[0].Name <- label
    
    durations
    |> Seq.iteri (fun i d ->
        view.Columns.[i+1].Name <- sprintf "%d months" d)

    view.Dock <- DockStyle.Fill
    view.AllowUserToAddRows <- false
    view


let setRowBreakEven repayment D C (row : DataGridViewRow) =
    let solveInterest = solveInterest repayment

    let goal = 0.0
    let values =
        durations
        |> Seq.map (fun N -> solveInterest N D C goal |> formatPerCent)

    values
    |> Seq.iteri (fun i v ->
        row.Cells.[1+i].Value <- box v)

    
let setRowLoss repayment D C (row : DataGridViewRow) =    
    let c = convertAnnualToMonthly C
    let d = computeMonthlyRisk D
    let losses =
        durations
        |> Seq.map (fun N -> payments (repayment N 1.0 0.0) d c)
        |> Seq.map formatPerCent

    losses
    |> Seq.iteri (fun i v ->
        row.Cells.[1+i].Value <- box v)


let addRow init (grid : DataGridView) =
    let pos = grid.Rows.Add(1)
    init (grid.Rows.[pos]) |> ignore
    grid


let addRowBreakEven label D C grid =
    grid
    |> addRow (fun row -> row.Cells.[0].Value <- label ; setRowBreakEven Repayment.constant D C row)


let addRowLoss label D C grid =
    grid
    |> addRow (fun row -> row.Cells.[0].Value <- label ; setRowLoss Repayment.constant D C row)
