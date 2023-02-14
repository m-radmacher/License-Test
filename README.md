These are the commands I used to create the key pair.
I'm using `Ubuntu 22.04.1 LTS (GNU/Linux 5.15.79.1-microsoft-standard-WSL2 x86_64)` to generate them, but the program (both the C# and NodeJS part) is run on a Windows 11 machine.

The Password used for the key pair is `pass`.

```bash
# Generate a new key pair
openssl genrsa -aes256 -out private.key 2048
# Generate the associated public key
openssl rsa -in private.key -RSAPublicKey_out -outform "MS PRIVATEKEYBLOB" -out public.pem
```

Now I created a signature for the test.txt

```bash
# Create a binary signature for the test.txt
openssl dgst -sha256 -sign private.key -out test.txt.sign test.txt
# Convert signature to base64 for readability
openssl base64 -in test.txt.sign -out test.txt.sign.base64
```

To verify the signature using openssl, I used the following command:

```bash
openssl dgst -sha256 -verify public.pem -signature test.txt.sign test.txt
```


# C# Program

I created a simple C# console application that should allow you to debug the issue.
It's based on .Net Framework 4.8 and does not use any external libraries.

# NodeJS Program

I used Typescript as that is also used in the real program, so you'll have to use pnpm to install the dependencies.

```bash
pnpm install
```

After that you can start the program using

```bash
pnpm dev
```

This will overwrite the signature in the `test.txt.sign` file with a new signature.
