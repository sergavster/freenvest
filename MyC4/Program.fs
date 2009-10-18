// Learn more about F# at http://fsharp.net

open InterestFinder
open System
open System.Drawing
open System.Windows.Forms

(*
compCountry Repayment.constant "Kenya" 0.04 0.118
compCountry Repayment.constant "Uganda Gatsby" 0.025 0.24
compCountry Repayment.constant "Tanzania" 0.01 0.17
compCountry Repayment.constant "Eurocard" 0.04 0.0
*)

[<STAThread>]
do Application.EnableVisualStyles()
let view = new DataGridView()
view.ColumnCount <- 6
view.Columns.[0].Name <- ""
view.Columns.[1].Name <- "6 months"
view.Columns.[2].Name <- "12 months"
view.Columns.[3].Name <- "15 months"
view.Columns.[4].Name <- "18 months"
view.Columns.[5].Name <- "24 months"

view.Rows.Add(1) |> ignore
setRowBreakEven (view.Rows.[0]) Repayment.constant 0.04 0.118

view.Rows.Add(1) |> ignore
setRowLoss (view.Rows.[1]) Repayment.constant 0.04 0.118

view.Dock <- DockStyle.Fill

let f = new Form()
f.Controls.Add(view)

Application.Run(f)