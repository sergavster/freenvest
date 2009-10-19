// Learn more about F# at http://fsharp.net

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

let viewLoss = RatesGridView.newGridView "Losses at 0%"
viewLoss
|> RatesGridView.addRowLoss "Kenya (D 4% C 11.8%)" 0.04 0.118
|> RatesGridView.addRowLoss "Uganda (D 2.5% C 24%)" 0.025 0.24
|> RatesGridView.addRowLoss "Tanzania (D 1% C 17%)" 0.01 0.17
|> ignore

let viewBreakEven = RatesGridView.newGridView "Rates for 0% loss"
viewBreakEven
|> RatesGridView.addRowBreakEven "Kenya (D 4% C 11.8%)" 0.04 0.118
|> RatesGridView.addRowBreakEven "Uganda (D 2.5% C 24%)" 0.025 0.24
|> RatesGridView.addRowBreakEven "Tanzania (D 1% C 17%)" 0.01 0.17
|> ignore

let f = new Form()

let splitter = new SplitContainer()
splitter.Dock <- DockStyle.Fill
splitter.Orientation <- Orientation.Horizontal

splitter.Panel1.Controls.Add(viewLoss)
splitter.Panel2.Controls.Add(viewBreakEven)

f.Controls.Add(splitter)

Application.Run(f)