# CoolValidator - Validate TexBox now is easy
<br/>
#How to install
```Install-Package coolvalidator```

#How to use 
Import its namespace 
```using CoolValidator;```

You can use default validator

[![code_dafault.png](https://s16.postimg.org/9qao83lo5/code_dafault.png)](https://postimg.org/image/txo40ej5d/)

<ul>
<li><b>ValidateType.IS_EMPTY</b> - Check If the TextBox is empty</li>
<li><b>PosValidateAction</b> - The method that will run after validation</li>
</ul>

You can use a custom validator

[![code_customValid.png](https://s16.postimg.org/wqhbkfjhx/code_custom_Valid.png)](https://postimg.org/image/huiscu835/)

<ul>
<li><b>ValidateType.NONE</b> - Indicate that none validate it will be executed</li>
<li><b>PosValidateAction</b> - The method that will run after validation</li>
<li><b>c => string.IsNullOrEmpty(c.Text) && c.Tag.Equals("Required")</b> - Your conditional to validate your TexBox, Your condition to validate a TextBox, you can put anything.</li>
</ul>
