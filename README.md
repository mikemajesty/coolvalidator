# CoolValidator - Validate TexBox now is easy

##How to install
```
  Install-Package coolvalidator
```

##How to use 
<h4>First of all import the project namespace</h4>
```
  using CoolValidator;
```
</hr>
##Validate TextBox
</hr>
<h4>You can use default validator</h4>

[![code_dafault.png](https://s16.postimg.org/9qao83lo5/code_dafault.png)](https://postimg.org/image/txo40ej5d/)

* ``` ValidateType.IS_EMPTY ``` - Check If the TextBox is empty


<ul>
<li><b> ValidateType.IS_EMPTY</b> - Check If the TextBox is empty</li>
<li><b>PosValidateAction</b> - The method that will run after validation</li>
</ul>
</hr>
<h4>You can use a custom validator</h4>

[![code_customValid.png](https://s16.postimg.org/wqhbkfjhx/code_custom_Valid.png)](https://postimg.org/image/huiscu835/)

<ul>
<li><b>ValidateType.NONE</b> - Indicate that none validate it will be executed</li>
<li><b>PosValidateAction</b> - The method that will run after validation</li>
<li><b>c => string.IsNullOrEmpty(c.Text) && c.Tag.Equals("Required")</b> - Your condition to validate a TextBox, you can put anything.</li>
</ul>
</hr>
To validate the example above it's necessary that TextBox be empty and its Tag property be "Required"

[![loco.png](https://s13.postimg.org/lauhc9h5j/loco.png)](https://postimg.org/image/vkwwbi70z/)

<h4>You can use custom and default validator</h4>

[![code_defaultAndCustom.png](https://s16.postimg.org/tyy1ttkz9/code_default_And_Custom.png)](https://postimg.org/image/5v7a5j2i9/)

<ul>
<li><b>ValidateType.IS_EMPTY</b> - Check If the TextBox is empty</li>
<li><b>PosValidateAction</b> - The method that will run after validation</li>
<li><b>c => c.Tag.Equals("Required")</b> - Your condition to validate a TextBox, you can put anything.</li>
</ul>
