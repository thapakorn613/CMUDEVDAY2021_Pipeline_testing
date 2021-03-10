# CMUDEVDAY2021_Pipeline_testing

GIT REPOSITORY นี้ ใช้สำหรับเป็น Code ตัวอย่างที่สามารถรองรับการทำ Automate Test ผ่าน Azure pipeline  <br/>

local run Pre request <br/>
1 ติดตั้ง .NET5 SDK https://dotnet.microsoft.com/download/dotnet/5.0 <br/>
2 ติดตั้ง Visual Code https://code.visualstudio.com/download <br/>

วิธี run test  บน local ด้วย dotnet cli <br/>
1 dotnet test ApiTest <br/>
2 dotnet test UnitTestRepository<br/>

วิธี Automate Test ผ่าน Azure pipeline <br/>
1 สร้าง new project บน Azure DevOps <br/>
2 push code เข้า branch master บน Azure DevOps Repository ของ new Project <br/>
3 Azure DevOps จะ Automate Test ผ่าน Azure pipeline ให้เองเพราะมี  azure-pipelines.yml ใน git แล้ว
