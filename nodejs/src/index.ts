import * as crypto from "crypto";
import * as fs from "fs";

const signFile = (base64: boolean) => {
  const file = fs.readFileSync("../data/test.txt");
  const sign = crypto.createSign("SHA256");
  sign.update(file);
  const signature = sign.sign(
    {
      key: getPrivateKey(),
      passphrase: "pass",
    },
  );
  fs.writeFileSync("../data/test.txt.sign", base64 ? signature.toString("base64") : signature);
};

const getPrivateKey = () => {
  return fs.readFileSync("../data/private.key", { encoding: "utf-8" });
};

// Change this to false to create a binary signature or true to create a base64 signature
signFile(false);
