package com.example.android.spanishquiz;

import android.graphics.Color;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    int score = 0;
    boolean first = false, second = false, third = false, fourth = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void first(View view) {
        Button button = findViewById(R.id.button1);
        CheckBox check1 = findViewById(R.id.check1);
        CheckBox check2 = findViewById(R.id.check2);
        CheckBox check3 = findViewById(R.id.check3);
        CheckBox check4 = findViewById(R.id.check4);
        TextView corr = findViewById(R.id.corr1);
        if (check1.isChecked() && check2.isChecked() && !check3.isChecked() && !check4.isChecked())
            score++;
        else {
            corr.setText(getResources().getString(R.string.incorrect));
            corr.setTextColor(Color.RED);
        }
        button.setVisibility(Button.GONE);
        corr.setVisibility(TextView.VISIBLE);
        first = true;
        summary();
    }

    public void second(View view) {
        Button button = findViewById(R.id.button2);
        RadioButton radio = findViewById(R.id.radiob1);
        TextView corr = findViewById(R.id.corr2);
        if (radio.isChecked())
            score++;
        else {
            corr.setText(getResources().getString(R.string.incorrect));
            corr.setTextColor(Color.RED);
        }
        button.setVisibility(Button.GONE);
        corr.setVisibility(TextView.VISIBLE);
        second = true;
        summary();
    }

    public void third(View view) {
        Button button = findViewById(R.id.button3);
        EditText edit = findViewById(R.id.editText1);
        TextView corr = findViewById(R.id.corr3);
        if (edit.getText().toString().toLowerCase().equals("embarazada"))
            score++;
        else {
            corr.setText(getResources().getString(R.string.incorrect));
            corr.setTextColor(Color.RED);
        }
        button.setVisibility(Button.GONE);
        corr.setVisibility(TextView.VISIBLE);
        third = true;
        summary();
    }

    public void fourth(View view) {
        Button button = findViewById(R.id.button4);
        RadioButton radio = findViewById(R.id.radiob2);
        TextView corr = findViewById(R.id.corr4);
        if (radio.isChecked())
            score++;
        else {
            corr.setText(getResources().getString(R.string.incorrect));
            corr.setTextColor(Color.RED);
        }
        button.setVisibility(Button.GONE);
        corr.setVisibility(TextView.VISIBLE);
        fourth = true;
        summary();
    }

    private void summary() {
        if (first && second && third && fourth) {
            Toast toast = Toast.makeText(this, getResources().getString(R.string.score) + score + "/4", Toast.LENGTH_LONG);
            toast.show();
        }
    }
}
