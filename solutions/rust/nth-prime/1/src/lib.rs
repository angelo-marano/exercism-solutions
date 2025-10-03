pub fn nth(n: u32) -> u32 {
    let mut p = Primes::new();
    p.nth(n as usize).unwrap()
}

struct Primes {
    curr: u32,
}

fn is_prime(n: u32) -> bool {
    if n < 2 {
        return false;
    }
    let limit = (n as f64).sqrt() as u32 + 1;
    for i in 2..limit {
        if n % i == 0 {
            return false;
        }
    }
    true
}

impl Iterator for Primes {
    type Item = u32;

    fn next(&mut self) -> Option<Self::Item> {
        self.curr += 1;
        loop {
            println!("current: {0}", self.curr);
            if is_prime(self.curr) {
                return Some(self.curr);
            }
            self.curr += 1;
        }
    }
}

impl Primes {
    fn new() -> Primes {
        Primes { curr: 0 }
    }
}
