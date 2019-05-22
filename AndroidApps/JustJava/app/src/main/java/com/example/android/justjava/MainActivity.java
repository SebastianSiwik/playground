/**
 * IMPORTANT: Make sure you are using the correct package name.
 * This example uses the package name:
 * package com.example.android.justjava
 * If you get an error when copying this code into Android studio, update it to match teh package name found
 * in the project's AndroidManifest.xml file.
 **/

package com.example.android.justjava;


import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

/**
 * This app displays an order form to order coffee.
 */
public class MainActivity extends AppCompatActivity {

    int quantity = 2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    /**
     * This method is called when the order button is clicked.
     */
    public void submitOrder(View view) {
        EditText textField = findViewById(R.id.textField);
        String name = textField.getText().toString();
        Intent intent = new Intent(Intent.ACTION_SENDTO);
        intent.setData(Uri.parse("mailto:")); // only email apps should handle this
        intent.putExtra(Intent.EXTRA_SUBJECT, getString(R.string.jjorder) + name);
        intent.putExtra(Intent.EXTRA_TEXT, createOrderSummary(calculatePrice()));
        if (intent.resolveActivity(getPackageManager()) != null) {
            startActivity(intent);
        }

    }

    private String createOrderSummary(int price) {
        CheckBox whippedCreamCheckBox = findViewById(R.id.whippedCreamCheckBox);
        CheckBox chocolateCheckBox = findViewById(R.id.chocolateCheckBox);
        EditText textField = findViewById(R.id.textField);
        boolean hasWhippedCream = whippedCreamCheckBox.isChecked();
        boolean hasChocolate = chocolateCheckBox.isChecked();
        String name = textField.getText().toString();
        Log.v("MainActivity", "Has whipped cream: " + hasWhippedCream);
        Log.v("MainActivity", "Has chocolate: " + hasChocolate);
        Log.v("MainActivity", "Name: " + name);
        if(hasWhippedCream) price += 1;
        if(hasChocolate) price += 2;
        return getString(R.string.name) + name + getString(R.string.addWhippedCream) + hasWhippedCream + getString(R.string.addChocolate)
                + hasChocolate + getString(R.string.quantity) + quantity + getString(R.string.total) + price + getString(R.string.thank_you);
    }

    /**
     * This method displays the given quantity value on the screen.
     */
    private void displayQuantity(int quantity) {
        TextView quantityTextView = (TextView) findViewById(R.id.quantity_text_view);
        quantityTextView.setText("" + quantity);
    }

    /**
     * Calculates the price of the order.
     */
    private int calculatePrice() {
        return quantity * 5;
    }

    public void increment(View view) {
        if(quantity < 100)
        quantity = quantity + 1;
        else{
            Toast toast = Toast.makeText(this, getString(R.string.too_many), Toast.LENGTH_SHORT);
            toast.show();
        }
        displayQuantity(quantity);
    }

    public void decrement(View view) {
        if(quantity > 1)
        quantity = quantity - 1;
        else{
            Toast toast = Toast.makeText(this, getString(R.string.too_few), Toast.LENGTH_SHORT);
            toast.show();
        }
        displayQuantity(quantity);
    }
}