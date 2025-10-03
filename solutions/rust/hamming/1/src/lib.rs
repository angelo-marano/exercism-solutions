/// Return the Hamming distance between the strings,
/// or None if the lengths are mismatched.
pub fn hamming_distance(s1: &str, s2: &str) -> Option<usize> {
    let c1 = s1.chars();
    let c2 = s2.chars();

    match s1.len() != s2.len() {
        true => return None,
        false => Some(c1.zip(c2).filter(|(a, b)| a != b).count()),
    }
}
