#pragma once
#include "MyForm1.h"
#include "Login.h"
#include <fstream>
#include <string>
#include <msclr\marshal_cppstd.h>
#include <time.h>
#include <cmath>
#include <iomanip>
#include <sstream>

namespace sklep {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	struct sklep {
		std::string art;
		double ile;
	};

	double count[19];

	std::string globalAutkam;
	std::fstream magazyn, historia;
	double calcNum = 0;
	bool newNum = true;

	double cena[] = {2.09, 4.51, 4.41, 4.96, 4.64, 6.00, 8.50, 9.00, 4.30, 3.25, 13.55, 5.70, 9.80, 2.90, 5.85, 9.70, 45.00, 27.00, 3.20};
	sklep art[19];
	sklep ile[19];

	/// <summary>
	/// Podsumowanie informacji o MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: W tym miejscu dodaj kod konstruktora
			//
		}

	protected:
		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Panel^  panel1;
	protected:





	private: System::Windows::Forms::Panel^  panel4;
	private: System::Windows::Forms::Panel^  panel2;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Panel^  panel3;
	private: System::Windows::Forms::Button^  button4;
	private: System::Windows::Forms::Button^  button3;

	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::ListBox^  listBox1;
	private: System::Windows::Forms::Button^  button6;

	private: System::Windows::Forms::Panel^  panel9;
	private: System::Windows::Forms::Panel^  panel8;
	private: System::Windows::Forms::Panel^  panel7;
	private: System::Windows::Forms::Panel^  panel6;
	private: System::Windows::Forms::Panel^  panel5;
	private: System::Windows::Forms::Label^  label7;
	private: System::Windows::Forms::Label^  label6;
	private: System::Windows::Forms::Label^  label5;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Button^  button7;
	private: System::Windows::Forms::Label^  label8;
	private: System::Windows::Forms::Button^  button23;
	private: System::Windows::Forms::Button^  button25;
	private: System::Windows::Forms::Button^  button26;
	private: System::Windows::Forms::Button^  button27;
	private: System::Windows::Forms::Button^  button18;
	private: System::Windows::Forms::Button^  button19;
	private: System::Windows::Forms::Button^  button20;
	private: System::Windows::Forms::Button^  button21;
	private: System::Windows::Forms::Button^  button22;
	private: System::Windows::Forms::Button^  button13;
	private: System::Windows::Forms::Button^  button14;
	private: System::Windows::Forms::Button^  button15;
	private: System::Windows::Forms::Button^  button16;
	private: System::Windows::Forms::Button^  button17;
	private: System::Windows::Forms::Button^  button12;
	private: System::Windows::Forms::Button^  button11;
	private: System::Windows::Forms::Button^  button10;
	private: System::Windows::Forms::Button^  button9;
	private: System::Windows::Forms::Button^  button8;
	private: System::Windows::Forms::Button^  button24;
	private: System::Windows::Forms::Label^  label9;
	private: System::Windows::Forms::Panel^  panel10;
	private: System::Windows::Forms::NumericUpDown^  numericUpDown1;
	private: System::Windows::Forms::Button^  button2;
	private: System::Drawing::Printing::PrintDocument^  printDocument1;

	private: System::Windows::Forms::PrintPreviewDialog^  printPreviewDialog1;
	private: System::Drawing::Printing::PrintDocument^  printDocument2;

	private: System::Windows::Forms::PrintPreviewDialog^  printPreviewDialog2;
	private: System::Windows::Forms::Button^  button28;
	private: System::Windows::Forms::Timer^  timer1;
	private: System::Windows::Forms::Label^  label10;
	private: System::ComponentModel::IContainer^  components;

	protected:

	private:
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Metoda wymagana do obsługi projektanta — nie należy modyfikować
		/// jej zawartości w edytorze kodu.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(MyForm::typeid));
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->panel9 = (gcnew System::Windows::Forms::Panel());
			this->label7 = (gcnew System::Windows::Forms::Label());
			this->panel8 = (gcnew System::Windows::Forms::Panel());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->panel7 = (gcnew System::Windows::Forms::Panel());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->panel6 = (gcnew System::Windows::Forms::Panel());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->panel5 = (gcnew System::Windows::Forms::Panel());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->panel4 = (gcnew System::Windows::Forms::Panel());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->panel2 = (gcnew System::Windows::Forms::Panel());
			this->panel10 = (gcnew System::Windows::Forms::Panel());
			this->label8 = (gcnew System::Windows::Forms::Label());
			this->label9 = (gcnew System::Windows::Forms::Label());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->button24 = (gcnew System::Windows::Forms::Button());
			this->button23 = (gcnew System::Windows::Forms::Button());
			this->button25 = (gcnew System::Windows::Forms::Button());
			this->button26 = (gcnew System::Windows::Forms::Button());
			this->button27 = (gcnew System::Windows::Forms::Button());
			this->button18 = (gcnew System::Windows::Forms::Button());
			this->button19 = (gcnew System::Windows::Forms::Button());
			this->button20 = (gcnew System::Windows::Forms::Button());
			this->button21 = (gcnew System::Windows::Forms::Button());
			this->button22 = (gcnew System::Windows::Forms::Button());
			this->button13 = (gcnew System::Windows::Forms::Button());
			this->button14 = (gcnew System::Windows::Forms::Button());
			this->button15 = (gcnew System::Windows::Forms::Button());
			this->button16 = (gcnew System::Windows::Forms::Button());
			this->button17 = (gcnew System::Windows::Forms::Button());
			this->button12 = (gcnew System::Windows::Forms::Button());
			this->button11 = (gcnew System::Windows::Forms::Button());
			this->button10 = (gcnew System::Windows::Forms::Button());
			this->button9 = (gcnew System::Windows::Forms::Button());
			this->button8 = (gcnew System::Windows::Forms::Button());
			this->panel3 = (gcnew System::Windows::Forms::Panel());
			this->button28 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->numericUpDown1 = (gcnew System::Windows::Forms::NumericUpDown());
			this->button7 = (gcnew System::Windows::Forms::Button());
			this->button6 = (gcnew System::Windows::Forms::Button());
			this->button4 = (gcnew System::Windows::Forms::Button());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->listBox1 = (gcnew System::Windows::Forms::ListBox());
			this->printDocument1 = (gcnew System::Drawing::Printing::PrintDocument());
			this->printPreviewDialog1 = (gcnew System::Windows::Forms::PrintPreviewDialog());
			this->printDocument2 = (gcnew System::Drawing::Printing::PrintDocument());
			this->printPreviewDialog2 = (gcnew System::Windows::Forms::PrintPreviewDialog());
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->label10 = (gcnew System::Windows::Forms::Label());
			this->panel1->SuspendLayout();
			this->panel9->SuspendLayout();
			this->panel8->SuspendLayout();
			this->panel7->SuspendLayout();
			this->panel6->SuspendLayout();
			this->panel5->SuspendLayout();
			this->panel4->SuspendLayout();
			this->panel2->SuspendLayout();
			this->panel10->SuspendLayout();
			this->panel3->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->numericUpDown1))->BeginInit();
			this->SuspendLayout();
			// 
			// panel1
			// 
			this->panel1->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->panel1->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"panel1.BackgroundImage")));
			this->panel1->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->panel1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->panel1->Controls->Add(this->panel9);
			this->panel1->Controls->Add(this->panel8);
			this->panel1->Controls->Add(this->panel7);
			this->panel1->Controls->Add(this->panel6);
			this->panel1->Controls->Add(this->panel5);
			this->panel1->Controls->Add(this->panel4);
			this->panel1->Location = System::Drawing::Point(72, 0);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(1524, 243);
			this->panel1->TabIndex = 0;
			// 
			// panel9
			// 
			this->panel9->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->panel9->Controls->Add(this->label7);
			this->panel9->Location = System::Drawing::Point(1276, 3);
			this->panel9->Name = L"panel9";
			this->panel9->Size = System::Drawing::Size(234, 240);
			this->panel9->TabIndex = 3;
			// 
			// label7
			// 
			this->label7->BackColor = System::Drawing::SystemColors::GradientInactiveCaption;
			this->label7->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label7->Font = (gcnew System::Drawing::Font(L"Lato", 48, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label7->Location = System::Drawing::Point(0, 0);
			this->label7->Name = L"label7";
			this->label7->Size = System::Drawing::Size(234, 240);
			this->label7->TabIndex = 1;
			this->label7->Text = L"6";
			this->label7->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// panel8
			// 
			this->panel8->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->panel8->Controls->Add(this->label6);
			this->panel8->Location = System::Drawing::Point(1020, 2);
			this->panel8->Name = L"panel8";
			this->panel8->Size = System::Drawing::Size(234, 240);
			this->panel8->TabIndex = 1;
			// 
			// label6
			// 
			this->label6->BackColor = System::Drawing::SystemColors::GradientInactiveCaption;
			this->label6->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label6->Font = (gcnew System::Drawing::Font(L"Lato", 48, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label6->Location = System::Drawing::Point(0, 0);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(234, 240);
			this->label6->TabIndex = 1;
			this->label6->Text = L"5";
			this->label6->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// panel7
			// 
			this->panel7->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->panel7->Controls->Add(this->label5);
			this->panel7->Location = System::Drawing::Point(766, 2);
			this->panel7->Name = L"panel7";
			this->panel7->Size = System::Drawing::Size(234, 240);
			this->panel7->TabIndex = 1;
			// 
			// label5
			// 
			this->label5->BackColor = System::Drawing::SystemColors::GradientInactiveCaption;
			this->label5->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label5->Font = (gcnew System::Drawing::Font(L"Lato", 48, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label5->Location = System::Drawing::Point(0, 0);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(234, 240);
			this->label5->TabIndex = 1;
			this->label5->Text = L"4";
			this->label5->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// panel6
			// 
			this->panel6->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->panel6->Controls->Add(this->label4);
			this->panel6->Location = System::Drawing::Point(512, 2);
			this->panel6->Name = L"panel6";
			this->panel6->Size = System::Drawing::Size(234, 240);
			this->panel6->TabIndex = 2;
			// 
			// label4
			// 
			this->label4->BackColor = System::Drawing::SystemColors::GradientInactiveCaption;
			this->label4->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label4->Font = (gcnew System::Drawing::Font(L"Lato", 48, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label4->Location = System::Drawing::Point(0, 0);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(234, 240);
			this->label4->TabIndex = 1;
			this->label4->Text = L"3";
			this->label4->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// panel5
			// 
			this->panel5->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->panel5->Controls->Add(this->label3);
			this->panel5->Location = System::Drawing::Point(261, 2);
			this->panel5->Name = L"panel5";
			this->panel5->Size = System::Drawing::Size(234, 240);
			this->panel5->TabIndex = 1;
			// 
			// label3
			// 
			this->label3->BackColor = System::Drawing::SystemColors::GradientInactiveCaption;
			this->label3->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label3->Font = (gcnew System::Drawing::Font(L"Lato", 48, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label3->Location = System::Drawing::Point(0, 0);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(234, 240);
			this->label3->TabIndex = 0;
			this->label3->Text = L"2";
			this->label3->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// panel4
			// 
			this->panel4->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->panel4->Controls->Add(this->label2);
			this->panel4->Location = System::Drawing::Point(8, -1);
			this->panel4->Name = L"panel4";
			this->panel4->Size = System::Drawing::Size(234, 240);
			this->panel4->TabIndex = 0;
			// 
			// label2
			// 
			this->label2->BackColor = System::Drawing::SystemColors::GradientInactiveCaption;
			this->label2->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label2->Font = (gcnew System::Drawing::Font(L"Lato", 48, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label2->Location = System::Drawing::Point(0, 0);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(234, 240);
			this->label2->TabIndex = 0;
			this->label2->Text = L"1";
			this->label2->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// panel2
			// 
			this->panel2->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->panel2->BackColor = System::Drawing::SystemColors::MenuHighlight;
			this->panel2->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"panel2.BackgroundImage")));
			this->panel2->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->panel2->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->panel2->Controls->Add(this->panel10);
			this->panel2->Controls->Add(this->button24);
			this->panel2->Controls->Add(this->button23);
			this->panel2->Controls->Add(this->button25);
			this->panel2->Controls->Add(this->button26);
			this->panel2->Controls->Add(this->button27);
			this->panel2->Controls->Add(this->button18);
			this->panel2->Controls->Add(this->button19);
			this->panel2->Controls->Add(this->button20);
			this->panel2->Controls->Add(this->button21);
			this->panel2->Controls->Add(this->button22);
			this->panel2->Controls->Add(this->button13);
			this->panel2->Controls->Add(this->button14);
			this->panel2->Controls->Add(this->button15);
			this->panel2->Controls->Add(this->button16);
			this->panel2->Controls->Add(this->button17);
			this->panel2->Controls->Add(this->button12);
			this->panel2->Controls->Add(this->button11);
			this->panel2->Controls->Add(this->button10);
			this->panel2->Controls->Add(this->button9);
			this->panel2->Controls->Add(this->button8);
			this->panel2->Location = System::Drawing::Point(3, 266);
			this->panel2->Name = L"panel2";
			this->panel2->Size = System::Drawing::Size(490, 562);
			this->panel2->TabIndex = 1;
			// 
			// panel10
			// 
			this->panel10->BackColor = System::Drawing::Color::White;
			this->panel10->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->panel10->Controls->Add(this->label8);
			this->panel10->Controls->Add(this->label9);
			this->panel10->Controls->Add(this->label1);
			this->panel10->Location = System::Drawing::Point(8, 15);
			this->panel10->MaximumSize = System::Drawing::Size(472, 166);
			this->panel10->Name = L"panel10";
			this->panel10->Size = System::Drawing::Size(472, 166);
			this->panel10->TabIndex = 24;
			// 
			// label8
			// 
			this->label8->AutoSize = true;
			this->label8->BackColor = System::Drawing::Color::White;
			this->label8->Location = System::Drawing::Point(3, -1);
			this->label8->MaximumSize = System::Drawing::Size(472, 0);
			this->label8->Name = L"label8";
			this->label8->Size = System::Drawing::Size(0, 17);
			this->label8->TabIndex = 1;
			// 
			// label9
			// 
			this->label9->AutoSize = true;
			this->label9->BackColor = System::Drawing::Color::White;
			this->label9->Font = (gcnew System::Drawing::Font(L"Lato", 36, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label9->Location = System::Drawing::Point(0, 93);
			this->label9->Name = L"label9";
			this->label9->Size = System::Drawing::Size(0, 72);
			this->label9->TabIndex = 23;
			this->label9->TextAlign = System::Drawing::ContentAlignment::BottomLeft;
			// 
			// label1
			// 
			this->label1->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->label1->BackColor = System::Drawing::Color::White;
			this->label1->Font = (gcnew System::Drawing::Font(L"Lato", 36, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label1->Location = System::Drawing::Point(59, -1);
			this->label1->MaximumSize = System::Drawing::Size(412, 166);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(412, 166);
			this->label1->TabIndex = 0;
			this->label1->TextAlign = System::Drawing::ContentAlignment::BottomRight;
			// 
			// button24
			// 
			this->button24->Font = (gcnew System::Drawing::Font(L"Lato", 36, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button24->Location = System::Drawing::Point(297, 186);
			this->button24->Name = L"button24";
			this->button24->Size = System::Drawing::Size(90, 87);
			this->button24->TabIndex = 22;
			this->button24->Text = L"C";
			this->button24->UseVisualStyleBackColor = true;
			this->button24->Click += gcnew System::EventHandler(this, &MyForm::button24_Click);
			// 
			// button23
			// 
			this->button23->Font = (gcnew System::Drawing::Font(L"Lato", 36, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button23->Location = System::Drawing::Point(393, 464);
			this->button23->Name = L"button23";
			this->button23->Size = System::Drawing::Size(90, 87);
			this->button23->TabIndex = 21;
			this->button23->Text = L"=";
			this->button23->UseVisualStyleBackColor = true;
			this->button23->Click += gcnew System::EventHandler(this, &MyForm::button23_Click);
			// 
			// button25
			// 
			this->button25->Font = (gcnew System::Drawing::Font(L"Lato", 25.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button25->Location = System::Drawing::Point(201, 464);
			this->button25->Name = L"button25";
			this->button25->Size = System::Drawing::Size(90, 87);
			this->button25->TabIndex = 19;
			this->button25->Text = L"0.";
			this->button25->UseVisualStyleBackColor = true;
			this->button25->Click += gcnew System::EventHandler(this, &MyForm::button25_Click);
			// 
			// button26
			// 
			this->button26->Font = (gcnew System::Drawing::Font(L"Lato", 36, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button26->Location = System::Drawing::Point(105, 464);
			this->button26->Name = L"button26";
			this->button26->Size = System::Drawing::Size(90, 87);
			this->button26->TabIndex = 18;
			this->button26->Text = L".";
			this->button26->UseVisualStyleBackColor = true;
			this->button26->Click += gcnew System::EventHandler(this, &MyForm::button26_Click);
			// 
			// button27
			// 
			this->button27->Font = (gcnew System::Drawing::Font(L"Lato", 25.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button27->Location = System::Drawing::Point(9, 464);
			this->button27->Name = L"button27";
			this->button27->Size = System::Drawing::Size(90, 87);
			this->button27->TabIndex = 17;
			this->button27->Text = L"0";
			this->button27->UseVisualStyleBackColor = true;
			this->button27->Click += gcnew System::EventHandler(this, &MyForm::button27_Click);
			// 
			// button18
			// 
			this->button18->Font = (gcnew System::Drawing::Font(L"Lato", 36, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button18->Location = System::Drawing::Point(297, 371);
			this->button18->Name = L"button18";
			this->button18->Size = System::Drawing::Size(90, 87);
			this->button18->TabIndex = 16;
			this->button18->Text = L"−";
			this->button18->UseVisualStyleBackColor = true;
			this->button18->Click += gcnew System::EventHandler(this, &MyForm::button18_Click);
			// 
			// button19
			// 
			this->button19->Font = (gcnew System::Drawing::Font(L"Lato", 36, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button19->Location = System::Drawing::Point(297, 464);
			this->button19->Name = L"button19";
			this->button19->Size = System::Drawing::Size(90, 87);
			this->button19->TabIndex = 15;
			this->button19->Text = L"+";
			this->button19->UseVisualStyleBackColor = true;
			this->button19->Click += gcnew System::EventHandler(this, &MyForm::button19_Click);
			// 
			// button20
			// 
			this->button20->Font = (gcnew System::Drawing::Font(L"Lato", 25.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button20->Location = System::Drawing::Point(201, 371);
			this->button20->Name = L"button20";
			this->button20->Size = System::Drawing::Size(90, 87);
			this->button20->TabIndex = 14;
			this->button20->Text = L"3";
			this->button20->UseVisualStyleBackColor = true;
			this->button20->Click += gcnew System::EventHandler(this, &MyForm::button20_Click);
			// 
			// button21
			// 
			this->button21->Font = (gcnew System::Drawing::Font(L"Lato", 25.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button21->Location = System::Drawing::Point(105, 371);
			this->button21->Name = L"button21";
			this->button21->Size = System::Drawing::Size(90, 87);
			this->button21->TabIndex = 13;
			this->button21->Text = L"2";
			this->button21->UseVisualStyleBackColor = true;
			this->button21->Click += gcnew System::EventHandler(this, &MyForm::button21_Click);
			// 
			// button22
			// 
			this->button22->Font = (gcnew System::Drawing::Font(L"Lato", 25.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button22->Location = System::Drawing::Point(9, 371);
			this->button22->Name = L"button22";
			this->button22->Size = System::Drawing::Size(90, 87);
			this->button22->TabIndex = 12;
			this->button22->Text = L"1";
			this->button22->UseVisualStyleBackColor = true;
			this->button22->Click += gcnew System::EventHandler(this, &MyForm::button22_Click);
			// 
			// button13
			// 
			this->button13->Font = (gcnew System::Drawing::Font(L"Lato", 36, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button13->Location = System::Drawing::Point(395, 371);
			this->button13->Name = L"button13";
			this->button13->Size = System::Drawing::Size(90, 87);
			this->button13->TabIndex = 11;
			this->button13->Text = L"÷";
			this->button13->UseVisualStyleBackColor = true;
			this->button13->Click += gcnew System::EventHandler(this, &MyForm::button13_Click);
			// 
			// button14
			// 
			this->button14->Font = (gcnew System::Drawing::Font(L"Lato", 36, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button14->Location = System::Drawing::Point(393, 278);
			this->button14->Name = L"button14";
			this->button14->Size = System::Drawing::Size(90, 87);
			this->button14->TabIndex = 10;
			this->button14->Text = L"×";
			this->button14->UseVisualStyleBackColor = true;
			this->button14->Click += gcnew System::EventHandler(this, &MyForm::button14_Click);
			// 
			// button15
			// 
			this->button15->Font = (gcnew System::Drawing::Font(L"Lato", 25.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button15->Location = System::Drawing::Point(201, 278);
			this->button15->Name = L"button15";
			this->button15->Size = System::Drawing::Size(90, 87);
			this->button15->TabIndex = 9;
			this->button15->Text = L"6";
			this->button15->UseVisualStyleBackColor = true;
			this->button15->Click += gcnew System::EventHandler(this, &MyForm::button15_Click);
			// 
			// button16
			// 
			this->button16->Font = (gcnew System::Drawing::Font(L"Lato", 25.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button16->Location = System::Drawing::Point(105, 278);
			this->button16->Name = L"button16";
			this->button16->Size = System::Drawing::Size(90, 87);
			this->button16->TabIndex = 8;
			this->button16->Text = L"5";
			this->button16->UseVisualStyleBackColor = true;
			this->button16->Click += gcnew System::EventHandler(this, &MyForm::button16_Click);
			// 
			// button17
			// 
			this->button17->Font = (gcnew System::Drawing::Font(L"Lato", 25.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button17->Location = System::Drawing::Point(9, 278);
			this->button17->Name = L"button17";
			this->button17->Size = System::Drawing::Size(90, 87);
			this->button17->TabIndex = 7;
			this->button17->Text = L"4";
			this->button17->UseVisualStyleBackColor = true;
			this->button17->Click += gcnew System::EventHandler(this, &MyForm::button17_Click);
			// 
			// button12
			// 
			this->button12->Font = (gcnew System::Drawing::Font(L"Lato", 36, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button12->Location = System::Drawing::Point(297, 278);
			this->button12->Name = L"button12";
			this->button12->Size = System::Drawing::Size(90, 87);
			this->button12->TabIndex = 6;
			this->button12->Text = L"√";
			this->button12->UseVisualStyleBackColor = true;
			this->button12->Click += gcnew System::EventHandler(this, &MyForm::button12_Click);
			// 
			// button11
			// 
			this->button11->Font = (gcnew System::Drawing::Font(L"Lato", 36, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button11->Location = System::Drawing::Point(393, 186);
			this->button11->Name = L"button11";
			this->button11->Size = System::Drawing::Size(90, 87);
			this->button11->TabIndex = 5;
			this->button11->Text = L"%";
			this->button11->UseVisualStyleBackColor = true;
			this->button11->Click += gcnew System::EventHandler(this, &MyForm::button11_Click);
			// 
			// button10
			// 
			this->button10->Font = (gcnew System::Drawing::Font(L"Lato", 25.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button10->Location = System::Drawing::Point(201, 185);
			this->button10->Name = L"button10";
			this->button10->Size = System::Drawing::Size(90, 87);
			this->button10->TabIndex = 4;
			this->button10->Text = L"9";
			this->button10->UseVisualStyleBackColor = true;
			this->button10->Click += gcnew System::EventHandler(this, &MyForm::button10_Click);
			// 
			// button9
			// 
			this->button9->Font = (gcnew System::Drawing::Font(L"Lato", 25.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button9->Location = System::Drawing::Point(105, 185);
			this->button9->Name = L"button9";
			this->button9->Size = System::Drawing::Size(90, 87);
			this->button9->TabIndex = 3;
			this->button9->Text = L"8";
			this->button9->UseVisualStyleBackColor = true;
			this->button9->Click += gcnew System::EventHandler(this, &MyForm::button9_Click);
			// 
			// button8
			// 
			this->button8->Font = (gcnew System::Drawing::Font(L"Lato", 25.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->button8->Location = System::Drawing::Point(9, 186);
			this->button8->Name = L"button8";
			this->button8->Size = System::Drawing::Size(90, 87);
			this->button8->TabIndex = 2;
			this->button8->Text = L"7";
			this->button8->UseVisualStyleBackColor = true;
			this->button8->Click += gcnew System::EventHandler(this, &MyForm::button8_Click);
			// 
			// panel3
			// 
			this->panel3->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->panel3->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"panel3.BackgroundImage")));
			this->panel3->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->panel3->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->panel3->Controls->Add(this->button28);
			this->panel3->Controls->Add(this->button2);
			this->panel3->Controls->Add(this->numericUpDown1);
			this->panel3->Controls->Add(this->button7);
			this->panel3->Controls->Add(this->button6);
			this->panel3->Controls->Add(this->button4);
			this->panel3->Controls->Add(this->button3);
			this->panel3->Controls->Add(this->button1);
			this->panel3->Controls->Add(this->listBox1);
			this->panel3->Font = (gcnew System::Drawing::Font(L"Lato", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->panel3->Location = System::Drawing::Point(511, 266);
			this->panel3->Name = L"panel3";
			this->panel3->Size = System::Drawing::Size(1174, 562);
			this->panel3->TabIndex = 2;
			// 
			// button28
			// 
			this->button28->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->button28->Location = System::Drawing::Point(900, 204);
			this->button28->Name = L"button28";
			this->button28->Size = System::Drawing::Size(238, 80);
			this->button28->TabIndex = 10;
			this->button28->Text = L"Drukuj stan magazynu";
			this->button28->UseVisualStyleBackColor = true;
			this->button28->Click += gcnew System::EventHandler(this, &MyForm::button28_Click);
			// 
			// button2
			// 
			this->button2->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->button2->Location = System::Drawing::Point(900, 291);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(238, 80);
			this->button2->TabIndex = 9;
			this->button2->Text = L"Historia transakcji";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &MyForm::button2_Click);
			// 
			// numericUpDown1
			// 
			this->numericUpDown1->DecimalPlaces = 2;
			this->numericUpDown1->Location = System::Drawing::Point(524, 427);
			this->numericUpDown1->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1000000, 0, 0, 0 });
			this->numericUpDown1->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 0 });
			this->numericUpDown1->Name = L"numericUpDown1";
			this->numericUpDown1->Size = System::Drawing::Size(164, 31);
			this->numericUpDown1->TabIndex = 8;
			this->numericUpDown1->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 0 });
			// 
			// button7
			// 
			this->button7->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->button7->Location = System::Drawing::Point(900, 117);
			this->button7->Name = L"button7";
			this->button7->Size = System::Drawing::Size(238, 80);
			this->button7->TabIndex = 7;
			this->button7->Text = L"Magazyn";
			this->button7->UseVisualStyleBackColor = true;
			this->button7->Click += gcnew System::EventHandler(this, &MyForm::button7_Click);
			// 
			// button6
			// 
			this->button6->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->button6->Location = System::Drawing::Point(900, 378);
			this->button6->Name = L"button6";
			this->button6->Size = System::Drawing::Size(238, 80);
			this->button6->TabIndex = 6;
			this->button6->Text = L"Drukuj historię transakcji";
			this->button6->UseVisualStyleBackColor = true;
			this->button6->Click += gcnew System::EventHandler(this, &MyForm::button6_Click);
			// 
			// button4
			// 
			this->button4->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->button4->AutoSize = true;
			this->button4->Location = System::Drawing::Point(712, 291);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(167, 167);
			this->button4->TabIndex = 4;
			this->button4->Text = L"Finalizuj";
			this->button4->UseVisualStyleBackColor = true;
			this->button4->Click += gcnew System::EventHandler(this, &MyForm::button4_Click);
			// 
			// button3
			// 
			this->button3->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->button3->AutoSize = true;
			this->button3->Location = System::Drawing::Point(712, 117);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(167, 167);
			this->button3->TabIndex = 3;
			this->button3->Text = L"Anuluj";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &MyForm::button3_Click);
			// 
			// button1
			// 
			this->button1->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->button1->AutoSize = true;
			this->button1->Location = System::Drawing::Point(524, 117);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(164, 304);
			this->button1->TabIndex = 1;
			this->button1->Text = L"Dodaj";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm::button1_Click);
			// 
			// listBox1
			// 
			this->listBox1->AccessibleDescription = L"";
			this->listBox1->AccessibleName = L"";
			this->listBox1->AccessibleRole = System::Windows::Forms::AccessibleRole::None;
			this->listBox1->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->listBox1->FormattingEnabled = true;
			this->listBox1->ItemHeight = 24;
			this->listBox1->Items->AddRange(gcnew cli::array< System::Object^  >(19) {
				L"LPG\t\t\t2.09 zł/l", L"ON\t\t\t4.51 zł/l", L"ON TIR\t\t\t4.41 zł/l",
					L"Pb98\t\t\t4.96 zł/l", L"Pb95\t\t\t4.64 zł/l", L"Hot-dog\t\t\t6.00 zł/szt", L"Kanapka\t\t\t8.50 zł/szt", L"Zapiekanka\t\t9.00 zł/szt",
					L"Kawa\t\t\t4.30 zł/szt", L"Gumy do żucia\t\t3.25 zł/szt ", L"Papierosy\t\t\t13.55 zł/pacz", L"Cukierki\t\t\t5.70 zł/pacz", L"Czekolada\t\t9.80 zł/szt",
					L"Baton\t\t\t2.90 zł/szt", L"Czipsy\t\t\t5.85 zł/pacz", L"Baterie\t\t\t9.70 zł/pacz", L"Olej silnikowy\t\t45.00 zł/szt", L"Płyn do spryskiwaczy\t27.00 zł/szt",
					L"Skrobaczka\t\t3.20 zł/szt"
			});
			this->listBox1->Location = System::Drawing::Point(30, 49);
			this->listBox1->Name = L"listBox1";
			this->listBox1->Size = System::Drawing::Size(431, 484);
			this->listBox1->TabIndex = 0;
			// 
			// printDocument1
			// 
			this->printDocument1->PrintPage += gcnew System::Drawing::Printing::PrintPageEventHandler(this, &MyForm::printDocument1_PrintPage);
			// 
			// printPreviewDialog1
			// 
			this->printPreviewDialog1->AutoScrollMargin = System::Drawing::Size(0, 0);
			this->printPreviewDialog1->AutoScrollMinSize = System::Drawing::Size(0, 0);
			this->printPreviewDialog1->ClientSize = System::Drawing::Size(400, 300);
			this->printPreviewDialog1->Document = this->printDocument1;
			this->printPreviewDialog1->Enabled = true;
			this->printPreviewDialog1->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"printPreviewDialog1.Icon")));
			this->printPreviewDialog1->Name = L"printPreviewDialog1";
			this->printPreviewDialog1->Visible = false;
			// 
			// printDocument2
			// 
			this->printDocument2->PrintPage += gcnew System::Drawing::Printing::PrintPageEventHandler(this, &MyForm::printDocument2_PrintPage);
			// 
			// printPreviewDialog2
			// 
			this->printPreviewDialog2->AutoScrollMargin = System::Drawing::Size(0, 0);
			this->printPreviewDialog2->AutoScrollMinSize = System::Drawing::Size(0, 0);
			this->printPreviewDialog2->ClientSize = System::Drawing::Size(400, 300);
			this->printPreviewDialog2->Document = this->printDocument2;
			this->printPreviewDialog2->Enabled = true;
			this->printPreviewDialog2->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"printPreviewDialog2.Icon")));
			this->printPreviewDialog2->Name = L"printPreviewDialog2";
			this->printPreviewDialog2->Visible = false;
			// 
			// timer1
			// 
			this->timer1->Enabled = true;
			this->timer1->Interval = 1000;
			this->timer1->Tick += gcnew System::EventHandler(this, &MyForm::timer1_Tick);
			// 
			// label10
			// 
			this->label10->AutoSize = true;
			this->label10->BackColor = System::Drawing::Color::Transparent;
			this->label10->Font = (gcnew System::Drawing::Font(L"Bahnschrift", 36, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label10->ForeColor = System::Drawing::SystemColors::Highlight;
			this->label10->Location = System::Drawing::Point(1875, -7);
			this->label10->Name = L"label10";
			this->label10->Size = System::Drawing::Size(0, 72);
			this->label10->TabIndex = 3;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::GradientActiveCaption;
			this->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"$this.BackgroundImage")));
			this->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->ClientSize = System::Drawing::Size(1697, 840);
			this->Controls->Add(this->label10);
			this->Controls->Add(this->panel3);
			this->Controls->Add(this->panel2);
			this->Controls->Add(this->panel1);
			this->MaximizeBox = false;
			this->Name = L"MyForm";
			this->Text = L"MyForm";
			this->WindowState = System::Windows::Forms::FormWindowState::Maximized;
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->panel1->ResumeLayout(false);
			this->panel9->ResumeLayout(false);
			this->panel8->ResumeLayout(false);
			this->panel7->ResumeLayout(false);
			this->panel6->ResumeLayout(false);
			this->panel5->ResumeLayout(false);
			this->panel4->ResumeLayout(false);
			this->panel2->ResumeLayout(false);
			this->panel10->ResumeLayout(false);
			this->panel10->PerformLayout();
			this->panel3->ResumeLayout(false);
			this->panel3->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->numericUpDown1))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
private: System::Void button7_Click(System::Object^  sender, System::EventArgs^  e) {
		
	OutMagazyn();

}
private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {

	if (Convert::ToDouble(numericUpDown1->Text)) {
		
		String^ cnt;

		count[listBox1->SelectedIndex] += Convert::ToDouble(numericUpDown1->Text);
		if (listBox1->SelectedIndex > 4) {
			int x = Convert::ToInt32(floor(Convert::ToDouble(numericUpDown1->Text)));
			cnt = "(" + Convert::ToString(x) + ")";
		} else
			cnt = "(" + Convert::ToString(numericUpDown1->Text) + ")";

		std::string items = msclr::interop::marshal_as<std::string>(label8->Text);
		String^ itemsS;
		String^ curItemS = listBox1->SelectedItem->ToString();
		std::string curItem = msclr::interop::marshal_as<std::string>(curItemS);
		if (!label8->Text->Contains("...")) {
			if (label8->Text->Length >= 288) {
				items.append("...");
				itemsS = gcnew String(items.c_str());
				label8->Text = itemsS;
			}
			else {
				int i = 0;
				while (i <= curItem.length()) {
					if (curItem[i] == '\t') {
						curItem[i] = '\0';
						break;
					}
					i++;
				}

				curItemS = gcnew String(curItem.c_str());
				curItemS += cnt;

				curItem = msclr::interop::marshal_as<std::string>(curItemS);

				if (label8->Text->Length != 0)
					items.append(" + ");
				items.append(curItem);
				itemsS = gcnew String(items.c_str());
				label8->Text = itemsS;
			}
		}
		numericUpDown1->Text = "1";
	}

}
private: System::Void MyForm_Load(System::Object^  sender, System::EventArgs^  e) {
	
	this->Hide();
	Login^ form = gcnew Login(this);
	form->Show();

}
private: System::Void button8_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);

	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	number.append("7");
	String^ numberS = gcnew String(number.c_str());
	label1->Text = numberS;

}
private: System::Void button9_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);

	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	number.append("8");
	String^ numberS = gcnew String(number.c_str());
	label1->Text = numberS;

}
private: System::Void button10_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);
	
	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	number.append("9");
	String^ numberS = gcnew String(number.c_str());
	label1->Text = numberS;

}
private: System::Void button17_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);

	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	number.append("4");
	String^ numberS = gcnew String(number.c_str());
	label1->Text = numberS;

}
private: System::Void button16_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);

	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	number.append("5");
	String^ numberS = gcnew String(number.c_str());
	label1->Text = numberS;

}
private: System::Void button15_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);
	
	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	number.append("6");
	String^ numberS = gcnew String(number.c_str());
	label1->Text = numberS;

}
private: System::Void button22_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);
	
	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	number.append("1");
	String^ numberS = gcnew String(number.c_str());
	label1->Text = numberS;

}
private: System::Void button21_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);
	
	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	number.append("2");
	String^ numberS = gcnew String(number.c_str());
	label1->Text = numberS;

}
private: System::Void button20_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);

	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	number.append("3");
	String^ numberS = gcnew String(number.c_str());
	label1->Text = numberS;

}
private: System::Void button27_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);
	
	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	if (label1->Text != "0") {
		number.append("0");
		String^ numberS = gcnew String(number.c_str());
		label1->Text = numberS;
	}

}
private: System::Void button26_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);

	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	if (!label1->Text->Contains(".") && !String::IsNullOrEmpty(label1->Text)) {
		number.append(",");
		String^ numberS = gcnew String(number.c_str());
		label1->Text = numberS;
	}

}
private: System::Void button25_Click(System::Object^  sender, System::EventArgs^  e) {

	std::string number = msclr::interop::marshal_as<std::string>(label1->Text);

	if (newNum) {
		number = "";
		label1->ResetText();
		newNum = false;
	}

	if (String::IsNullOrEmpty(label1->Text)) {
		number.append("0,");
		String^ numberS = gcnew String(number.c_str());
		label1->Text = numberS;
	}

}
private: System::Void button24_Click(System::Object^  sender, System::EventArgs^  e) {

	label1->ResetText();
	label9->ResetText();
	calcNum = 0;
	newNum = true;

}
private: System::Void button19_Click(System::Object^  sender, System::EventArgs^  e) {

	if (!String::IsNullOrEmpty(label1->Text) && !label1->Text->EndsWith(".")) {

		std::string number = msclr::interop::marshal_as<std::string>(label1->Text);

		label9->Text = "+";
		calcNum = Convert::ToDouble(label1->Text);
		label1->Text = Convert::ToString(calcNum);

		newNum = true;
	}

}
private: System::Void button23_Click(System::Object^  sender, System::EventArgs^  e) {

	if (label9->Text == "+") {
		calcNum += Convert::ToDouble(label1->Text);
		label1->Text = Convert::ToString(calcNum);

		newNum = true;
		label9->ResetText();
	}

	if (label9->Text == "-") {
		calcNum -= Convert::ToDouble(label1->Text);
		label1->Text = Convert::ToString(calcNum);

		newNum = true;
		label9->ResetText();
	}

	if (label9->Text == "÷") {
		calcNum /= Convert::ToDouble(label1->Text);
		label1->Text = Convert::ToString(calcNum);

		newNum = true;
		label9->ResetText();
	}

	if (label9->Text == "×") {
		calcNum *= Convert::ToDouble(label1->Text);
		label1->Text = Convert::ToString(calcNum);

		newNum = true;
		label9->ResetText();
	}

}
private: System::Void button18_Click(System::Object^  sender, System::EventArgs^  e) {

	if (!String::IsNullOrEmpty(label1->Text) && !label1->Text->EndsWith(".")) {

		label9->Text = "-";
		calcNum = Convert::ToDouble(label1->Text);
		label1->Text = Convert::ToString(calcNum);

		newNum = true;
	}

}
private: System::Void button13_Click(System::Object^  sender, System::EventArgs^  e) {

	if (!String::IsNullOrEmpty(label1->Text) && !label1->Text->EndsWith(".")) {

		label9->Text = "÷";
		calcNum = Convert::ToDouble(label1->Text);
		label1->Text = Convert::ToString(calcNum);

		newNum = true;
	}

}
private: System::Void button14_Click(System::Object^  sender, System::EventArgs^  e) {

	if (!String::IsNullOrEmpty(label1->Text) && !label1->Text->EndsWith(".")) {

		label9->Text = "×";
		calcNum = Convert::ToDouble(label1->Text);
		label1->Text = Convert::ToString(calcNum);

		newNum = true;
	}

}
private: System::Void button12_Click(System::Object^  sender, System::EventArgs^  e) {

	if (!String::IsNullOrEmpty(label1->Text) && !label1->Text->EndsWith(".")) {

		calcNum = sqrt(Convert::ToDouble(label1->Text));
		label1->Text = Convert::ToString(calcNum);

		newNum = true;

		label9->ResetText();
	}

}
private: System::Void button11_Click(System::Object^  sender, System::EventArgs^  e) {

	if ((!String::IsNullOrEmpty(label1->Text) && !label1->Text->EndsWith(".")) && (label9->Text == "+" || label9->Text == "-" || label9->Text == "×" || label9->Text == "÷")) {
		
		if (label9->Text == "÷") {
			calcNum /= (Convert::ToDouble(label1->Text) / 100);
		}
		if (label9->Text == "×") {
			calcNum *= (Convert::ToDouble(label1->Text) / 100);
		}
		if (label9->Text == "+") {
			calcNum += (Convert::ToDouble(label1->Text) / 100);
		}
		if (label9->Text == "-") {
			calcNum -= (Convert::ToDouble(label1->Text) / 100);
		}
		label1->Text = Convert::ToString(calcNum);

		newNum = true;
		label9->ResetText();

	}

}
private: System::Void button3_Click(System::Object^  sender, System::EventArgs^  e) {

	if (label8->Text != "") {
		if (MessageBox::Show("Czy na pewno chcesz anulować transakcję?", "", MessageBoxButtons::YesNo, MessageBoxIcon::Question) == ::System::Windows::Forms::DialogResult::Yes) {
			label8->ResetText();
			numericUpDown1->Text = "1";
			for (short i = 0; i < 19; i++)
				count[i] = 0;
		}
	}
}
private: System::Void button4_Click(System::Object^  sender, System::EventArgs^  e) {

	if(label8->Text != "")
		Sell();

}
private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {

	MyForm1^ myForm1 = gcnew MyForm1();
	myForm1->Show();

}
private: System::Void printDocument1_PrintPage(System::Object^  sender, System::Drawing::Printing::PrintPageEventArgs^  e) {

	std::string info;
	std::string quantity;


	struct sklep *ptr1 = art;
	struct sklep *ptr2 = ile;
	char semicolon(';');

	magazyn.open("magazyn.txt", std::ios::in);

	if (magazyn.good()) {

		while (getline(magazyn, info, semicolon) && getline(magazyn, quantity)) {

			ptr1->art = info;
			ptr2->ile = atof(quantity.c_str());
			ptr1++;
			ptr2++;
		}
	}
	magazyn.close();

	std::string message = "Paliwa:\n";

	for (int i = 0; i <= 4; i++) {
		message.append(art[i].art);
		message.append(" - ");

		String^ mendokusei = "";
		std::string mendokse;
		mendokse = std::to_string(ile[i].ile);
		for (short index = 0;; index++) {
			if (mendokse[index] == '.') {
				mendokse[index + 3] = '\0';
				mendokusei = gcnew String(mendokse.c_str());
				mendokse = msclr::interop::marshal_as<std::string>(mendokusei);
				break;
			}
		}
		message.append(mendokse);
		message.append(" l\n");
	}
	message.append("\n");
	message.append("Inne artykuły:\n");
	for (int i = 5; i <= 18; i++) {
		message.append(art[i].art);
		message.append(" - ");
		message.append(std::to_string((int)ile[i].ile));
		message.append("\n");
	}

	String^ messageS = gcnew String(message.c_str());

	e->Graphics->DrawString(messageS, gcnew System::Drawing::Font("Arial", 24), Brushes::Black, (float)80, (float)80);

}
private: System::Void button6_Click(System::Object^  sender, System::EventArgs^  e) {

	printPreviewDialog2->ShowDialog();
	if (DialogResult == ::System::Windows::Forms::DialogResult::OK)
	{
		printDocument2->Print();
	}

}
private: System::Void printDocument2_PrintPage(System::Object^  sender, System::Drawing::Printing::PrintPageEventArgs^  e) {

	std::string transakcje;
	std::string info;
	std::fstream historia;

	historia.open("transakcje.txt", std::ios::in);

	if (historia.good()) {
		while (getline(historia, info)) {
			transakcje.append(info);
			transakcje.append("\n");
		}
	}

	historia.close();

	e->Graphics->DrawString(gcnew String(transakcje.c_str()), gcnew System::Drawing::Font("Arial", 16), Brushes::Black, (float)80, (float)80);

}
private: System::Void button28_Click(System::Object^  sender, System::EventArgs^  e) {

	printPreviewDialog1->ShowDialog();
	if (DialogResult == ::System::Windows::Forms::DialogResult::OK)
	{
		printDocument1->Print();
	}

}

		 //funkcje tu////////////////////////////////////////////////////////////////////////////


		 void OutMagazyn() {
			 std::string info;
			 std::string quantity;


			 struct sklep *ptr1 = art;
			 struct sklep *ptr2 = ile;
			 char semicolon(';');

			 magazyn.open("magazyn.txt", std::ios::in);

			 if (magazyn.good()) {

				 while (getline(magazyn, info, semicolon) && getline(magazyn, quantity)) {

					 ptr1->art = info;
					 ptr2->ile = atof(quantity.c_str());
					 ptr1++;
					 ptr2++;
				 }
			 }
			 magazyn.close();

			 std::string message = "Paliwa:\n";

			 for (int i = 0; i <= 4; i++) {
				 message.append(art[i].art);
				 message.append(" - ");

				 String^ mendokusei = "";
				 std::string mendokse;
				 mendokse = std::to_string(ile[i].ile);
				 for (short index = 0;; index++) {
					 if (mendokse[index] == '.') {
						 mendokse[index + 3] = '\0';
						 mendokusei = gcnew String(mendokse.c_str());
						 mendokse = msclr::interop::marshal_as<std::string>(mendokusei);
						 break;
					 }
				 }
				 message.append(mendokse);
				 message.append(" l\n");
			 }
			 message.append("\n");
			 message.append("Inne artykuły:\n");
			 for (int i = 5; i <= 18; i++) {
				 message.append(art[i].art);
				 message.append(" - ");
				 message.append(std::to_string((int)ile[i].ile));
				 message.append("\n");
			 }

			 String^ messageS = gcnew String(message.c_str());
			 MessageBox::Show(messageS, "Magazyn", MessageBoxButtons::OK, MessageBoxIcon::None);


		 }
		 void Sell() {
			 std::string info;
			 std::string quantity;

			 struct sklep *ptr1 = art;
			 struct sklep *ptr2 = ile;
			 char semicolon(';');

			 magazyn.open("magazyn.txt", std::ios::in);

			 if (magazyn.good()) {

				 while (getline(magazyn, info, semicolon) && getline(magazyn, quantity)) {

					 ptr1->art = info;
					 ptr2->ile = atof(quantity.c_str());
					 ptr1++;
					 ptr2++;
				 }
			 }
			 magazyn.close();

			 std::string mbx, autkam, laPregunta = "Czy na pewno chcesz sfinalizować transakcję?\n\n";

			 double cenaSuma = 0.00;

			 for (short i = 0; i < 19; i++) {
				 if (count[i] <= 0)
					 continue;
				 autkam.append(art[i].art);
				 autkam.append(":\nIlość: ");

				 if (i > 4)
					 autkam.append(std::to_string((int)count[i]));
				 else {
					 String^ mendokusei = "";
					 std::string mendokse = std::to_string(count[i]);
					 for (short index = 0;; index++) {
						 if (mendokse[index] == '.') {
							 mendokse[index + 3] = '\0';
							 mendokusei = gcnew String(mendokse.c_str());
							 mendokse = msclr::interop::marshal_as<std::string>(mendokusei);
							 break;
						 }
					 }
					 autkam.append(mendokse);
				 }
				 if (i > 4)
					 autkam.append("\nCena: ");
				 else
					 autkam.append("\nCena: ");
				 String^ mendokusei = "";
				 std::string mendokse = std::to_string(count[i] * cena[i]);
				 for (short index = 0;; index++) {
					 if (mendokse[index] == '.') {
						 mendokse[index + 3] = '\0';
						 mendokusei = gcnew String(mendokse.c_str());
						 mendokse = msclr::interop::marshal_as<std::string>(mendokusei);
						 break;
					 }
				 }
				 autkam.append(mendokse);
				 autkam.append(" zł\n");
				 cenaSuma += count[i] * cena[i];
				 autkam.append("\n");
			 }
			 String^ mendokusei = "";
			 std::string mendokse = std::to_string(cenaSuma);
			 for (short index = 0;; index++) {
				 if (mendokse[index] == '.') {
					 mendokse[index + 3] = '\0';
					 mendokusei = gcnew String(mendokse.c_str());
					 mendokse = msclr::interop::marshal_as<std::string>(mendokusei);
					 break;
				 }
			 }
			 autkam.append("\nSuma:\t");
			 autkam.append(mendokse);
			 autkam.append(" zł");

			 mbx = laPregunta + autkam;
			 globalAutkam = autkam;
			 bool error = false;
			 std::string specialErrorMessage = "W magazynie brakuje produktów w następującej ilości:\n\n";
			 for (short i = 0; i < 19; i++) {
				 if (count[i] > ile[i].ile) {
					 error = true;
					 specialErrorMessage.append(art[i].art);
					 specialErrorMessage.append(": ");
					 String^ mendokusei = "";
					 std::string mendokse;
					 if (i < 5) {
						 mendokse = std::to_string((double)(count[i] - ile[i].ile));
						 for (short index = 0;; index++) {
							 if (mendokse[index] == '.') {
								 mendokse[index + 3] = '\0';
								 mendokusei = gcnew String(mendokse.c_str());
								 mendokse = msclr::interop::marshal_as<std::string>(mendokusei);
								 break;
							 }
						 }
					 }
					 else {
						 mendokse = std::to_string(count[i] - ile[i].ile);
						 for (short index = 0;; index++) {
							 if (mendokse[index] == '.') {
								 mendokse[index] = '\0';
								 mendokusei = gcnew String(mendokse.c_str());
								 mendokse = msclr::interop::marshal_as<std::string>(mendokusei);
								 break;
							 }
						 }
					 }
					 specialErrorMessage.append(mendokse);
					 specialErrorMessage.append("\n");
				 }
			 }

			 if (error)
				 MessageBox::Show(gcnew String(specialErrorMessage.c_str()), "", MessageBoxButtons::OK, MessageBoxIcon::Error);

			 else if (MessageBox::Show(gcnew String(mbx.c_str()), "", MessageBoxButtons::YesNo, MessageBoxIcon::Question) == ::System::Windows::Forms::DialogResult::Yes) {

				 InTrans();
				 InMagazyn();

				 MessageBox::Show("Transakcja sfinalizowana!", "Gotowe", MessageBoxButtons::OK);

				 for (short i = 0; i < 19; i++) {
					 count[i] = 0;
				 }
			 }
		 }
		 void InTrans() {

			 label8->ResetText();
			 numericUpDown1->Text = "1";

			 historia.open("transakcje.txt", std::ios::app);

			 if (historia.good()) {
				 time_t czas;
				 time(&czas);
				 tm * t = localtime(&czas);

				 historia << (t->tm_year + 1900) << '-'
					 << (t->tm_mon + 1) << '-'
					 << t->tm_mday
					 << ' '
					 << t->tm_hour << ':'
					 << t->tm_min << "\n\n"
					 << globalAutkam << '\n'
					 << "__________________________________________________________________________\n\n";
			 }

			 historia.close();

		 }
		 void InMagazyn() {

			 magazyn.open("magazyn.txt", std::ios::trunc | std::ios::out);

			 if (magazyn.good()) {
				 for (short i = 0; i < 19; i++) {
					 ile[i].ile -= count[i];
					 magazyn << art[i].art << ';' << std::fixed << std::setprecision(2) << ile[i].ile << '\n';
				 }
			 }
			 magazyn.close();
		 }


		 ////////////////////////////////////////////////////////////////////////////////////////


private: System::Void timer1_Tick(System::Object^  sender, System::EventArgs^  e) {

	time_t czas;
	time(&czas);
	tm * t = localtime(&czas);

	std::stringstream ss;
	
	ss << std::setfill('0') << std::setw(2) << t->tm_hour << ':' << t->tm_min;

	std::string zegar = ss.str();

	label10->Text = gcnew String(zegar.c_str());

}
};
}