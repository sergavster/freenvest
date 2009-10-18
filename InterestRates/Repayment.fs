open System

/// Principal P and interests (for interest rate R % p.a.) are repaid over a
/// period of N months, with a constant monthly repayment.
let constant N P R =
    let n = float N
    if R > 0.0 then
        let r = R / 12.0
        let B = P * r / (1.0 - Math.Pow(1.0 - r, (float N)))
        seq {
            for i in 1..N -> B
        }
    else
        seq {
            for i in 1..N -> P / n
        }

/// Principal P is repaid evenly over a period of N months.
/// Monthly interests depend on the outstanding principal at the end of the month.
let constantPrincipal N P R =
    let n = float N
    let r = R / 12.0
    seq {
        for i in 1..N ->             
            P / n * (1.0  + r * (n - (float i)))
        }