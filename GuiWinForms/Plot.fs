open System.Windows.Forms
open System.Drawing

let drawLine (color : Color) (form : Form)  (values : float seq) orig_X orig_Y width height =
    let N =
        values
        |> Seq.length
    
    if N > 0 then
        let gd = form.CreateGraphics()
        use pen = new Pen(color)
        
        let min = Seq.min values
        let max = Seq.max values
        
        let scale =
            if max <= min
            then
                fun _ -> 0.0
            else
                fun x -> (x - min) / (max - min)
        
        let setY y =
            orig_Y + (float form.Height) * (1.0 - y)
            |> float32
            
        let pt = ref(PointF(float32 orig_X, scale (Seq.nth 0 values) |> setY))
                
        values
        |> Seq.skip 1
        |> Seq.iteri (fun i y ->
            let x = orig_X + (float form.Width) * (float (i+1)) / (float (N-1))
            let pt2 = new PointF(float32 x, scale y |> setY)
            gd.DrawLine(pen, !pt, pt2)
            pt := pt2
            )
