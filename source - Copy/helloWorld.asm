# int a = 5;
# pirntf("a=%d",a)

global  _main
extern  _printf

section .text
_main:
	mov eax, [a]
	push eax
    push    message
    call    _printf
    add     esp, 8
	mov eax, 0
    ret

section .data
a:dd 5
message: db  'a=%d', 10, 0