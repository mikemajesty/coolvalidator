# CoolValidator - Validate TexBox now is easy

## How to install
```
  Install-Package coolvalidator
```

## How to use
#### First of all import the project namespace
```
  using CoolValidator;
```

## Validate TextBox
___ 

#### You can use default validator
```C#
  private void btnSave(object sender, EventArgs e)
  {
      this.ValidateTextBox(ValidateType.IS_EMPTY, PostValidate);
  }

  private void PostValidate()
  {
      MessageBox.Show("Field is Required");
  }
```
<ul>
<li><b> ValidateType.IS_EMPTY</b> - Check If the TextBox is empty</li>
<li><b>PosValidateAction</b> - The method that will run after validation</li>
</ul>

___

#### You can use a custom validator

```C#
  private void btnSave(object sender, EventArgs e)
  {
      this.ValidateTextBox(ValidateType.NONE, PostValidate, c =>
                  string.IsNullOrEmpty(c.Text) && c.Tag.Equals("Required"));
  }

  private void PostValidate()
  {
      MessageBox.Show("Field is Required");
  }
``` 

<ul>
<li><b>ValidateType.NONE</b> - Indicate that none validate it will be executed</li>
<li><b>PosValidateAction</b> - The method that will run after validation</li>
<li><b>c => string.IsNullOrEmpty(c.Text) && c.Tag.Equals("Required")</b> - Your condition to validate a TextBox, you can put anything.</li>
</ul>

To validate the example above it's necessary that TextBox be empty and its Tag property be "Required"

[![required.png](https://s17.postimg.org/sxllw9n1r/required.png)](https://postimg.org/image/s82tjwmi3/)

#### You can use custom and default validator
```C#
  private void btnSave(object sender, EventArgs e)
  {
      this.ValidateTextBox(ValidateType.IS_EMPTY, PostValidate, c =>
                                          c.Tag.Equals("Required"));
  }

  private void PostValidate()
  {
      MessageBox.Show("Field is Required");
  }
```
<ul>
<li><b>ValidateType.IS_EMPTY</b> - Check If the TextBox is empty</li>
<li><b>PosValidateAction</b> - The method that will run after validation</li>
<li><b>c => c.Tag.Equals("Required")</b> - Your condition to validate a TextBox, you can put anything.</li>
</ul>

___
## Validate Entity
___

#### Firstly you have to create a class with Annotation, example

[![productClass.png](https://s13.postimg.org/evu7xzbpj/product_Class.png)](https://postimg.org/image/ceigqprsz/)

To validate your entity use 

[![validaTxtInFormPNG.png](https://s13.postimg.org/u4p78vbpj/valida_Txt_In_Form_PNG.png)](https://postimg.org/image/t2f0qbsw3/)

In the example above we took in the first error a list of possible errors, The error list is composed of

[![errorClass.png](https://s13.postimg.org/z0ns3g5jb/error_Class.png)](https://postimg.org/image/yb4zr34zn/)

Then we showed the error in a MessageBox

[![warning.png](https://s13.postimg.org/5cpl1muiv/warning.png)](https://postimg.org/image/k8o4985xf/)

You can do whatever you want with these error messages, make yourself comfortable

<hr>

### License

It is available under the MIT license.
[License](https://opensource.org/licenses/mit-license.php)
