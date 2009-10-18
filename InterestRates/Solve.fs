/// Find x in interval (min, max) such that f(x) is close to 0.0
let rec solve eps f min max =
    let x = (min + max) / 2.0
    if max - min <= eps
    then
        x
    else
        if f x >= 0.0 then
            solve eps f min x
        else
            solve eps f x max
