open System.Windows.Forms
open System.Drawing
open System


let drawLine (color : Color) (values : float seq) min max orig_X orig_Y width height (gd : Graphics) =
    let N =
        values
        |> Seq.length
    
    if N > 0 then
        use pen = new Pen(color)
                
        let scale =
            if max <= min
            then
                fun _ -> 0.0
            else
                fun x -> (x - min) / (max - min)
        
        let setY y =
            orig_Y + height * (1.0 - y)
            |> float32
            
        let pt = ref(PointF(float32 orig_X, scale (Seq.nth 0 values) |> setY))
                
        values
        |> Seq.skip 1
        |> Seq.iteri (fun i y ->
            let x = orig_X + width * (float (i+1)) / (float (N-1))
            let pt2 = new PointF(float32 x, scale y |> setY)
            gd.DrawLine(pen, !pt, pt2)
            pt := pt2
            )


let drawBackground (color : Color) min max (orig_X : float) (orig_Y : float) width height (gd : Graphics) =
    if min < max then
        use pen = new Pen(color)
        
        let diff = max - min
        let intrv = Math.Pow(10.0, Math.Floor(Math.Log10(diff)))
        
        printfn "   %f" intrv
        
        let setY y =
            let y = (y - min) / (max - min)
            orig_Y + height * (1.0 - y)
        
        let rec drawLines value =
            printfn "%f" value
            if value <= max then
                let y = setY value
                let pt0 = new PointF(float32 orig_X, float32 y)
                let pt1 = new PointF(float32 (orig_X + width), float32 y)
                
                gd.DrawLine(pen, pt0, pt1)
                drawLines (value + intrv)
        
        drawLines (intrv * Math.Ceiling(min / intrv))


let registerHandler (background_line_color : Color) (line_color : Color) (form : Form) =
    let handler (args : PaintEventArgs) =
        let width = float form.Width
        let height = float form.Height
        drawBackground background_line_color 0.0 9.0 (0.1 * width) (0.1 * height) (0.8 * width) (0.8 * height) args.Graphics
    
    form.Paint.Add handler
    