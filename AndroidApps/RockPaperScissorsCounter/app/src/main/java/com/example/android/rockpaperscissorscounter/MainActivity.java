package com.example.android.rockpaperscissorscounter;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.TextView;

import com.example.android.rockpaperscissorscounter.R;

public class MainActivity extends AppCompatActivity {

    int scoreTeamA = 0, scoreTeamB = 0;
    int rockA = 0, paperA = 0, scissorsA = 0;
    int rockB = 0, paperB = 0, scissorsB = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    /**
     * Displays the given score for Team A.
     */
    public void displayRockForTeamA(int score, int rock) {
        TextView scoreView = (TextView) findViewById(R.id.team_a_score);
        TextView rockView = (TextView) findViewById(R.id.rockA);
        scoreView.setText(String.valueOf(score));
        rockView.setText(String.valueOf(rock));
    }

    public void displayRockForTeamB(int score, int rock) {
        TextView scoreView = (TextView) findViewById(R.id.team_b_score);
        TextView rockView = (TextView) findViewById(R.id.rockB);
        scoreView.setText(String.valueOf(score));
        rockView.setText(String.valueOf(rock));
    }

    public void displayPaperForTeamA(int score, int paper) {
        TextView scoreView = (TextView) findViewById(R.id.team_a_score);
        TextView paperView = (TextView) findViewById(R.id.paperA);
        scoreView.setText(String.valueOf(score));
        paperView.setText(String.valueOf(paper));
    }

    public void displayPaperForTeamB(int score, int paper) {
        TextView scoreView = (TextView) findViewById(R.id.team_b_score);
        TextView paperView = (TextView) findViewById(R.id.paperB);
        scoreView.setText(String.valueOf(score));
        paperView.setText(String.valueOf(paper));
    }

    public void displayScissorsForTeamA(int score, int scissors) {
        TextView scoreView = (TextView) findViewById(R.id.team_a_score);
        TextView scissorsView = (TextView) findViewById(R.id.scissorsA);
        scoreView.setText(String.valueOf(score));
        scissorsView.setText(String.valueOf(scissors));
    }

    public void displayScissorsForTeamB(int score, int scissors) {
        TextView scoreView = (TextView) findViewById(R.id.team_b_score);
        TextView scissorsView = (TextView) findViewById(R.id.scissorsB);
        scoreView.setText(String.valueOf(score));
        scissorsView.setText(String.valueOf(scissors));
    }

    public void rockA(View view) {
        scoreTeamA += 1;
        rockA += 1;
        displayRockForTeamA(scoreTeamA, rockA);
    }

    public void paperA(View view) {
        scoreTeamA += 1;
        paperA += 1;
        displayPaperForTeamA(scoreTeamA, paperA);
    }

    public void scissorsA(View view) {
        scoreTeamA += 1;
        scissorsA += 1;
        displayScissorsForTeamA(scoreTeamA, scissorsA);
    }

    public void rockB(View view) {
        scoreTeamB += 1;
        rockB += 1;
        displayRockForTeamB(scoreTeamB, rockB);
    }

    public void paperB(View view) {
        scoreTeamB += 1;
        paperB += 1;
        displayPaperForTeamB(scoreTeamB, paperB);
    }

    public void scissorsB(View view) {
        scoreTeamB += 1;
        scissorsB += 1;
        displayScissorsForTeamB(scoreTeamB, scissorsB);
    }

    public void reset(View view) {
        scoreTeamA = 0;
        scoreTeamB = 0;
        rockA = 0;
        paperA = 0;
        scissorsA = 0;
        rockB = 0;
        paperB = 0;
        scissorsB = 0;
        displayRockForTeamA(scoreTeamA, rockA);
        displayRockForTeamB(scoreTeamA, rockB);
        displayPaperForTeamA(scoreTeamA, paperA);
        displayPaperForTeamB(scoreTeamA, paperB);
        displayScissorsForTeamA(scoreTeamA, scissorsA);
        displayScissorsForTeamB(scoreTeamA, scissorsB);
    }
}
