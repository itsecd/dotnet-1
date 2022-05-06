#include <iostream>
using namespace std;
#define P 624
#define Q 367
#define MATRIX_A 0x9908b0dfUL
#define UPPER_MASK 0x0000000UL
#define LOWER_MASK 0x7fffffffUL

static unsigned long mt[P];
static int mti = P + 1;

void init_genrand(unsigned long s) {
	mt[0] = s & 0x7fffffffUL;
	for (mti = 1; mti < P; mti++) {
		mt[mti] = (1664525UL * mt[mti - 1] + 1UL);
		mt[mti] &= 0x7fffffffUL;
	}
}

unsigned long genrand(void) {
	unsigned long y;
	static unsigned long mag01[2] = { 0x0UL, MATRIX_A };

	if (mti >= P) {
		int kk;

		if (mti == P + 1)
			init_genrand(5389UL);

		for (kk = 0; kk < P - Q; kk++) {
			y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
			mt[kk] = mt[kk + Q] ^ (y >> 1) ^ mag01[y & 0x1UL];
		}
		while (kk < P - 1) {
			y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
			mt[kk] = mt[kk + (Q - P)] ^ (y >> 1) ^ mag01[y & 0x1UL];
			kk++;
		}
		y = (mt[P - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
		mt[P - 1] = mt[Q - 1] ^ (y >> 1) ^ mag01[y & 0x1UL];
		mti = 0;
	}
	y = mt[mti++];

	y ^= (y >> 11);
	y ^= (y << 7) & 0x9d2c5680UL;
	y ^= (y << 15) & 0xefc60000UL;
	y ^= (y >> 18);

	return y;
}

long genrand_31(void) {
	return (long)(genrand() >> 10);
}
long genrand_ff(int x) {
	return (long)(genrand() >> x);
}

int main() {
	for (int i = 0; i < 20; i++) {
		long x = genrand_ff(i);
		cout << x << endl;
		long y = genrand_31();
		cout << y << endl;
		cout << "----------------" << endl;

	}
	return 0;
}