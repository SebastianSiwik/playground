#pragma once

namespace sklep {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Podsumowanie informacji o Login
	/// </summary>
	public ref class Login : public System::Windows::Forms::Form
	{
	private:
		System::Windows::Forms::Form ^ MyForm;

	public:
		Login(System::Windows::Forms::Form ^ o)
		{
			MyForm = o;
			InitializeComponent();
		}

	protected:
		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		~Login()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^  label1;
	protected:
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::MaskedTextBox^  maskedTextBox1;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::LinkLabel^  linkLabel1;

	private:
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Wymagana metoda obsługi projektanta — nie należy modyfikować 
		/// zawartość tej metody z edytorem kodu.
		/// </summary>
		void InitializeComponent(void)
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->maskedTextBox1 = (gcnew System::Windows::Forms::MaskedTextBox());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->linkLabel1 = (gcnew System::Windows::Forms::LinkLabel());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Perpetua Titling MT", 19.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label1->ForeColor = System::Drawing::Color::Black;
			this->label1->Location = System::Drawing::Point(249, 22);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(229, 39);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Logowanie";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Palatino Linotype", 10.2F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label2->Location = System::Drawing::Point(224, 89);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(52, 23);
			this->label2->TabIndex = 1;
			this->label2->Text = L"login:";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Font = (gcnew System::Drawing::Font(L"Palatino Linotype", 10.2F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label3->Location = System::Drawing::Point(221, 130);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(55, 23);
			this->label3->TabIndex = 2;
			this->label3->Text = L"hasło:";
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(282, 91);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(162, 22);
			this->textBox1->TabIndex = 3;
			// 
			// button1
			// 
			this->button1->Font = (gcnew System::Drawing::Font(L"Palatino Linotype", 7.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button1->Location = System::Drawing::Point(552, 205);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(98, 36);
			this->button1->TabIndex = 6;
			this->button1->Text = L"DALEJ";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Login::button1_Click);
			// 
			// maskedTextBox1
			// 
			this->maskedTextBox1->Location = System::Drawing::Point(282, 132);
			this->maskedTextBox1->Name = L"maskedTextBox1";
			this->maskedTextBox1->PasswordChar = '*';
			this->maskedTextBox1->Size = System::Drawing::Size(162, 22);
			this->maskedTextBox1->TabIndex = 5;
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->BackColor = System::Drawing::Color::Transparent;
			this->label4->Font = (gcnew System::Drawing::Font(L"Palatino Linotype", 7.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label4->ForeColor = System::Drawing::Color::Red;
			this->label4->Location = System::Drawing::Point(261, 61);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(208, 19);
			this->label4->TabIndex = 7;
			this->label4->Text = L"Nieprawidłowy login lub hasło";
			this->label4->Visible = false;
			// 
			// linkLabel1
			// 
			this->linkLabel1->AutoSize = true;
			this->linkLabel1->DisabledLinkColor = System::Drawing::Color::OliveDrab;
			this->linkLabel1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 7));
			this->linkLabel1->LinkColor = System::Drawing::Color::Olive;
			this->linkLabel1->Location = System::Drawing::Point(279, 157);
			this->linkLabel1->Name = L"linkLabel1";
			this->linkLabel1->Size = System::Drawing::Size(117, 15);
			this->linkLabel1->TabIndex = 8;
			this->linkLabel1->Text = L"Zapomniałem hasło";
			this->linkLabel1->LinkClicked += gcnew System::Windows::Forms::LinkLabelLinkClickedEventHandler(this, &Login::linkLabel1_LinkClicked);
			// 
			// Login
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::GradientActiveCaption;
			this->ClientSize = System::Drawing::Size(662, 253);
			this->Controls->Add(this->linkLabel1);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->maskedTextBox1);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 7.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
			this->MaximizeBox = false;
			this->MinimizeBox = false;
			this->Name = L"Login";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->FormClosed += gcnew System::Windows::Forms::FormClosedEventHandler(this, &Login::Login_FormClosed);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {

		if (textBox1->Text == "admin" && maskedTextBox1->Text == "admin") {
			this->Hide();
			MyForm->Show();
		}
		else
			label4->Visible = true;

	}
private: System::Void Login_FormClosed(System::Object^  sender, System::Windows::Forms::FormClosedEventArgs^  e) {

	MyForm->Close();

}
private: System::Void linkLabel1_LinkClicked(System::Object^  sender, System::Windows::Forms::LinkLabelLinkClickedEventArgs^  e) {

	linkLabel1->Text = "\"admin\"! :)";
	linkLabel1->LinkBehavior = System::Windows::Forms::LinkBehavior::NeverUnderline;

}
};
}
