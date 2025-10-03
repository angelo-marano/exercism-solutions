pub fn square(s: u32) -> u64 {
    let n = 2u64.pow(s - 1);
    n
}

pub fn total() -> u64 {
    (1..=64).map(square).sum()
}
