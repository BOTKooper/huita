#include <iostream>

#define VARIANT 13
using namespace std;

long a, b, c, a1, b1, c1, left_asm, right_asm, left_c, right_c;

int addOvf(int* result, int a, int b){
	*result = a + b;
	if (a > 0 && b > 0 && *result < 0)
		return -1;
	if (a < 0 && b < 0 && *result > 0)
		return -1;
	return 0;
}
int mulOvf(int* result, int a, int b){
	*result = a * b;
	if (a > 0 && b > 0 && *result < 0)
		return -1;
	if (a < 0 && b < 0 && *result > 0)
		return -1;
	return 0;
}

int main() {
	while (1) {
		cout << "Type a, b, c: ";
		cin >> a >> b >> c;

		a1 = a / (VARIANT + 2);
		b1 = b / (VARIANT + 3);
		c1 = c / (VARIANT + 4);

		left_c = (a1 - b1 + c1) * (a1 - b1 + c1);
		right_c = (a1 * a1) + (b1 * b1) + (c1 * c1) - (2 * a1 * b1) + (2 * a1 * c1) - (2 * b1 * c1);

		__asm {
			// a -> a1
			mov ebx, (VARIANT + 2)
			mov eax, a
			cdq
			idiv ebx
			mov a1, eax
			// b -> b1
			mov ebx, (VARIANT + 3)
			mov eax, b
			cdq
			idiv ebx
			mov b1, eax
			// c -> c1
			mov ebx, (VARIANT + 4)
			mov eax, c
			cdq
			idiv ebx
			mov c1, eax
			// (a1 - b1 + c1)
			mov eax, a1
			sub eax, b1
			add eax, c1
			mov ebx, eax
			// (a1 - b1 + c1)^2
			imul eax, eax
			mov left_asm, eax
			//////////////////////////////
			// a1^2
			mov eax, a1
			mov ebx, a1
			imul eax, ebx
			mov ecx, eax
			// a1^2 + b1^2
			mov eax, b1
			mov ebx, b1
			imul eax, ebx
			add ecx, eax
			// a1^2 + b1^2 + c1^2
			mov eax, c1
			mov ebx, c1
			imul eax, ebx
			add ecx, eax
			// a1^2 + b1^2 + c1^2 - (2 * a1 * b1)
			mov eax, 2
			mov ebx, a1
			imul eax, ebx
			mov ebx, b1
			imul eax, ebx
			sub ecx, eax
			// (a1 * a1) + (b1 * b1) + (c1 * c1) - (2 * a1 * b1) + (2 * a1 * c1)
			mov eax, 2
			mov ebx, a1
			imul eax, ebx
			mov ebx, c1
			imul eax, ebx
			add ecx, eax
			// (a1 * a1) + (b1 * b1) + (c1 * c1) - (2 * a1 * b1) + (2 * a1 * c1) - (2 * b1 * c1)
			mov eax, 2
			mov ebx, c1
			imul eax, ebx
			mov ebx, b1
			imul eax, ebx
			sub ecx, eax

			mov right_asm, ecx
		}

		cout <<
			"Left_C:    " << left_c << endl <<
			"Right_C:   " << right_c << endl <<
			"Left_ASM:  " << left_asm << endl <<
			"Right_ASM: " << right_asm << endl;
	}
	return 0;
}