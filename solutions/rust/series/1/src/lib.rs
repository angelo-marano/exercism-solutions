pub fn series(digits: &str, len: usize) -> Vec<String> {
    let mut vec: Vec<String> = Vec::new();
    let mut i = 0;
    let l = digits.len();
    while i + len <= l {
        let slice = digits[i..i + len].to_string();
        vec.push(slice);
        i += 1;
    }

    vec
}
