use std::collections::HashSet;

pub fn sum_of_multiples(limit: u32, factors: &[u32]) -> u32 {
    let mut numbers = HashSet::new();

    for f in factors {
        let lower = *f as usize;
        if lower == 0 {
            continue;
        }
        for i in (lower..limit as usize).step_by(lower) {
            numbers.insert(i as u32);
        }
    }

    let sum = numbers.iter().sum();
    return sum;
}
