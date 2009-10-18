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

let view = RatesGridView.newGridView()
view |> RatesGridView.addCountry "Default 4% Deprec. 11.8%" 0.04 0.118 |> ignore

let f = new Form()
f.Controls.Add(view)

Application.Run(f)