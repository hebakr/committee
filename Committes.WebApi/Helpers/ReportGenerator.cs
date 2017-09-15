using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Committes.WebApi.Models;

namespace Committes.WebApi.Helpers
{
    public static class ReportGenerator
    {
        public static void CreateDoc(string fileName, CommitteeVM data, byte part = 1)
        {
            // Create a Wordprocessing document. 
            using (WordprocessingDocument myDoc = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
            {
                // Add a new main document part. 
                MainDocumentPart mainPart = myDoc.AddMainDocumentPart();

                HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();
                FooterPart footerPart = mainPart.AddNewPart<FooterPart>();


                //Create DOM tree for simple document. 
                mainPart.Document = new Document();
                Body body = new Body();
                mainPart.Document.Append(body);

                SectionProperties sectionProps = new SectionProperties();
                PageMargin pageMargin = new PageMargin() { Top = 1008, Right = (UInt32Value)1008U, Bottom = 1008, Left = (UInt32Value)1008U, Header = (UInt32Value)720U, Footer = (UInt32Value)720U, Gutter = (UInt32Value)0U };
                sectionProps.Append(pageMargin);
                mainPart.Document.Body.Append(sectionProps);


                switch (part)
                {
                    case 1:
                        //Add master Table 
                        AddMasterTable(data, mainPart);
                        ApplyHeader(myDoc, data);
                        break;
                    case 2:
                        //Add third table 
                        AddThirdTable(data, mainPart);
                        ApplyHeader2(myDoc, data);
                        break;
                    case 3:
                        //Add second table 
                        AddSecondTable(data, mainPart);
                        ApplyHeader2(myDoc, data);
                        break;

                }

                ApplyFooter(myDoc);



                // Save changes to the main document part. 
                mainPart.Document.Save();
            }
        }

        private static void ApplyHeader2(WordprocessingDocument doc, CommitteeVM data)
        {
            // Get the main document part.
            MainDocumentPart mainDocPart = doc.MainDocumentPart;

            HeaderPart headerPart1 = mainDocPart.AddNewPart<HeaderPart>("r97");

            Header header1 = new Header();

            header1.Append(CreateParagraph(" استمارة رقم  14 د ", JustificationValues.Right, "", "12pt"));
            header1.Append(CreateParagraph($"أسماء السادة أعضاء لجنة {data.Name} رقم ({data.Number}) ", JustificationValues.Center, "", "15pt", true));
            header1.Append(CreateParagraph($"الدور {data.Term} {data.SchoolYear}  ", JustificationValues.Left, "", "12pt"));

            headerPart1.Header = header1;



            SectionProperties sectionProperties1 = mainDocPart.Document.Body.Descendants<SectionProperties>().FirstOrDefault();
            if (sectionProperties1 == null)
            {
                sectionProperties1 = new SectionProperties() { };
                mainDocPart.Document.Body.Append(sectionProperties1);
            }
            HeaderReference headerReference1 = new HeaderReference() { Type = HeaderFooterValues.Default, Id = "r97" };


            sectionProperties1.InsertAt(headerReference1, 0);
        }

        private static void AddThirdTable(CommitteeVM data, MainDocumentPart mainPart)
        {
            Table table = new Table();
            TableProperties props = new TableProperties(
            new TableWidth() { Width = "100%", Type = TableWidthUnitValues.Auto },

            new TableBorders(
            new TopBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 12
            },
            new BottomBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 12
            },
            new LeftBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 12
            },
            new RightBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 12
            },
            new InsideHorizontalBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 8
            },
            new InsideVerticalBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 8
            }));
            props.BiDiVisual = new BiDiVisual();

            table.AppendChild<TableProperties>(props);

            var headerRow = new TableRow();

            var bgColor = "#cccccc";

            headerRow.Append(CreateTableCell("م", bgColor, JustificationValues.Center, "5%"));
            headerRow.Append(CreateTableCell("الأســــــــــم", bgColor, JustificationValues.Center, "20%"));
            headerRow.Append(CreateTableCell("الوظيفة", bgColor, JustificationValues.Center, "45%"));
            headerRow.Append(CreateTableCell("ملاحظات", bgColor, JustificationValues.Center, "45%"));
            table.Append(headerRow);

            var counter = 1;


            foreach (var member in data.TheoroticalMembers)
            {
                var tr = new TableRow();

                tr.Append(CreateTableCell($"{counter++}", "", JustificationValues.Center));
                tr.Append(CreateTableCell(member.Name));
                tr.Append(CreateTableCell($"{member.Job}"));

                tr.Append(CreateTableCell(member.TheoroticalDate));

                table.Append(tr);
            }

            foreach (var member in data.Observers)
            {
                var tr = new TableRow();

                tr.Append(CreateTableCell($"{counter++}", "", JustificationValues.Center));
                tr.Append(CreateTableCell(member.Name));
                tr.Append(CreateTableCell($"{member.Job}"));

                tr.Append(CreateTableCell(member.StartDate));

                table.Append(tr);
            }


            mainPart.Document.Append(table);

        }

        private static void AddSecondTable(CommitteeVM data, MainDocumentPart mainPart)
        {
            Table table = new Table();
            TableProperties props = new TableProperties(
            new TableWidth() { Width = "100%", Type = TableWidthUnitValues.Auto },

            new TableBorders(
            new TopBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 12
            },
            new BottomBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 12
            },
            new LeftBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 12
            },
            new RightBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 12
            },
            new InsideHorizontalBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 8
            },
            new InsideVerticalBorder
            {
                Val = new EnumValue<BorderValues>(BorderValues.Single),
                Size = 8
            }));
            props.BiDiVisual = new BiDiVisual();

            table.AppendChild<TableProperties>(props);

            var headerRow = new TableRow();

            var bgColor = "#cccccc";

            headerRow.Append(CreateTableCell("م", bgColor, JustificationValues.Center, "5%"));
            headerRow.Append(CreateTableCell("الأســــــــــم", bgColor, JustificationValues.Center, "20%"));
            headerRow.Append(CreateTableCell("الوظيفة", bgColor, JustificationValues.Center, "45%"));
            headerRow.Append(CreateTableCell("ملاحظات", bgColor, JustificationValues.Center, "45%"));
            headerRow.Append(CreateTableCell("", bgColor, JustificationValues.Center, "45%"));
            headerRow.Append(CreateTableCell("", bgColor, JustificationValues.Center, "45%"));
            table.Append(headerRow);


            foreach (var item in data.Labs)
            {
                var tr = new TableRow();

                tr.Append(CreateTableCell(""));
                tr.Append(CreateTableCell(item.Title, bgColor, JustificationValues.Left, "", "", "12pt", true));
                tr.Append(CreateTableCell(""));

                tr.Append(CreateTableCell(""));
                tr.Append(CreateTableCell(""));
                tr.Append(CreateTableCell(""));

                table.Append(tr);
                var counter = 1;

                foreach (var member in item.Members)
                {
                    var tr2 = new TableRow();

                    tr2.Append(CreateTableCell($"{counter++}", "", JustificationValues.Center));
                    tr2.Append(CreateTableCell(member.Name));
                    tr2.Append(CreateTableCell($"{member.Job} {member.Speciality} {member.School.Title}"));

                    tr2.Append(CreateTableCell(member.CommitteRole));
                    tr2.Append(CreateTableCell(member.StartDate));
                    tr2.Append(CreateTableCell(member.EvaluationDate));

                    table.Append(tr2);
                }
            }

            foreach (var item in data.Divisions)
            {
                var tr = new TableRow();

                tr.Append(CreateTableCell(""));
                tr.Append(CreateTableCell(item.Title, bgColor, JustificationValues.Left, "", "", "12pt", true));
                tr.Append(CreateTableCell(""));

                tr.Append(CreateTableCell(""));
                tr.Append(CreateTableCell("امتحان"));
                tr.Append(CreateTableCell("تقدير درجات"));

                table.Append(tr);
                var counter = 1;

                foreach (var member in item.Members)
                {
                    var tr2 = new TableRow();

                    tr2.Append(CreateTableCell($"{counter++}", "", JustificationValues.Center));
                    tr2.Append(CreateTableCell(member.Name));
                    tr2.Append(CreateTableCell($"{member.Job} {member.Speciality} {member.School.Title}"));

                    tr2.Append(CreateTableCell(member.CommitteRole));
                    tr2.Append(CreateTableCell(member.StartDate));
                    tr2.Append(CreateTableCell(member.EvaluationDate));

                    table.Append(tr2);
                }
            }

            mainPart.Document.Append(table);
            //mainPart.Document.Append( new Paragraph(
            //  new Run(
            //    new Break() { Type = BreakValues.Page })));

        }

        private static void AddMasterTable(CommitteeVM data, MainDocumentPart mainPart)
        {
            Table table = new Table();

            TableProperties props = new TableProperties(
                new TableWidth() { Width = "100%", Type = TableWidthUnitValues.Auto },

                new TableBorders(
                new TopBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 12
                },
                new BottomBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 12
                },
                new LeftBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 12
                },
                new RightBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 12
                },
                new InsideHorizontalBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 8
                },
                new InsideVerticalBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 8
                }));
            props.BiDiVisual = new BiDiVisual();

            table.AppendChild<TableProperties>(props);

            var headerRow = new TableRow();

            var bgColor = "#cccccc";

            //var data = GetData();


            headerRow.Append(CreateTableCell("م", bgColor, JustificationValues.Center, "5%"));
            headerRow.Append(CreateTableCell("الإسم", bgColor, JustificationValues.Center, "20%"));
            headerRow.Append(CreateTableCell("الوظيفة", bgColor, JustificationValues.Center, "45%"));

            var cell4 = CreateTableCell("الملاحظات", bgColor, JustificationValues.Center);

            TableCellProperties tableCellProperties = new TableCellProperties()
            {
                TableCellVerticalAlignment = new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center },
                HorizontalMerge = new HorizontalMerge()
                {
                    Val = MergedCellValues.Restart

                }
            };

            cell4.Append(tableCellProperties);
            headerRow.Append(cell4);

            var cell5 = CreateTableCell("");
            cell5.Append(new TableCellProperties { HorizontalMerge = new HorizontalMerge { Val = MergedCellValues.Continue } });
            headerRow.Append(cell5);


            headerRow.TableRowProperties = new TableRowProperties();
            headerRow.TableRowProperties.AppendChild(new TableHeader());

            table.Append(headerRow);

            // add cheif and supervisor  
            var row2 = new TableRow();

            row2.Append(CreateTableCell("", "", JustificationValues.Center));
            var c1 = CreateTableCell("رئيس اللجنة", bgColor, JustificationValues.Left, "", "Arial", "14pt", true, true);
            c1.Append(CreateParagraph(data.Chief.Name));
            row2.Append(c1);
            row2.Append(CreateTableCell(data.Chief.Job));
            var r2c2 = CreateTableCell($"إستلام وإمتحان:- {data.Chief.StartDate}");
            r2c2.Append(CreateParagraph($"تسليم: {data.Chief.EndDate}"));
            row2.Append(r2c2);
            row2.Append(CreateTableCell($"تقدير الدرجات:- {data.Chief.EvaluationDate}"));
            table.Append(row2);

            var row3 = new TableRow();

            row3.Append(CreateTableCell("", "", JustificationValues.Center));
            var c2 = CreateTableCell("المراقب الأول", bgColor, JustificationValues.Left, "", "Arial", "14pt", true, true);
            c2.Append(CreateParagraph(data.SuperInspector.Name));
            row3.Append(c2);
            row3.Append(CreateTableCell(data.SuperInspector.Job));

            row3.Append(CreateTableCell(""));
            row3.Append(CreateTableCell(""));

            table.Append(row3);

            var row4 = new TableRow();

            row4.Append(CreateTableCell("", "", JustificationValues.Center));
            row4.Append(CreateTableCell("المراقبون", bgColor, JustificationValues.Left, "", "Arial", "12pt", true));
            row4.Append(CreateTableCell(""));

            row4.Append(CreateTableCell(""));
            row4.Append(CreateTableCell(""));

            table.Append(row4);

            var counter = 1;
            foreach (var item in data.Inspectors)
            {
                var tr = new TableRow();

                tr.Append(CreateTableCell($"{counter++}", "", JustificationValues.Center));
                tr.Append(CreateTableCell(item.Name));
                tr.Append(CreateTableCell($"{item.Job} {item.Speciality} {item.School.Title}"));

                tr.Append(CreateTableCell(item.StartDate));
                tr.Append(CreateTableCell(item.EvaluationDate));

                table.Append(tr);
            }

            var row5 = new TableRow();

            row5.Append(CreateTableCell("", "", JustificationValues.Center));
            row5.Append(CreateTableCell("المعاونـــــون", bgColor, JustificationValues.Left, "", "Arial", "12pt", true));
            row5.Append(CreateTableCell(""));

            row5.Append(CreateTableCell(""));
            row5.Append(CreateTableCell(""));

            table.Append(row5);

            counter = 1;
            foreach (var item in data.Assistances)
            {
                var tr = new TableRow();

                tr.Append(CreateTableCell($"{counter++}", "", JustificationValues.Center));
                tr.Append(CreateTableCell(item.Name));
                tr.Append(CreateTableCell($"{item.Job} {item.Speciality} {item.School.Title}"));

                tr.Append(CreateTableCell(item.StartDate));
                tr.Append(CreateTableCell(item.EvaluationDate));

                table.Append(tr);
            }

            var row6 = new TableRow();

            row6.Append(CreateTableCell("", "", JustificationValues.Center));
            row6.Append(CreateTableCell("الطبيب", bgColor, JustificationValues.Left, "", "Arial", "12pt", true));
            row6.Append(CreateTableCell(data.DoctorName));

            row6.Append(CreateTableCell(""));
            row6.Append(CreateTableCell(""));

            table.Append(row6);


            var row = table.GetFirstChild<TableRow>();



            mainPart.Document.Append(table);

            //var last = new Paragraph(
            //      new Run(
            //        new Break() { Type = BreakValues.Page }));

            //mainPart.Document.Append(last);
        }

        private static void ApplyHeader(WordprocessingDocument doc, CommitteeVM data)
        {
            // Get the main document part.
            MainDocumentPart mainDocPart = doc.MainDocumentPart;

            HeaderPart headerPart1 = mainDocPart.AddNewPart<HeaderPart>("r97");

            Header header1 = new Header();

            Table table = new Table();

            TableProperties props = new TableProperties(
                new TableWidth() { Width = "100%", Type = TableWidthUnitValues.Auto });

            props.BiDiVisual = new BiDiVisual();

            table.AppendChild<TableProperties>(props);
            var tr = new TableRow();
            //cell 1
            var tc = new TableCell();
            tc.Append(CreateParagraph(""));
            tc.Append(CreateParagraph("وزارة التربية و التعليم والتعليم الفني  الادارة العامة للامتحانات", JustificationValues.Center));
            tc.Append(CreateParagraph($"لجنة الإدارة لامتحان  دبلوم  المدارس الثانوية الصناعية نظام السنوات الثلاث قطاع {data.Sector}", JustificationValues.Center));
            var tableWidth = new TableCellWidth
            {
                Type = TableWidthUnitValues.Auto,
                Width = "28%"
            };
            tc.Append(new TableCellProperties(tableWidth));

            //cell 2
            var tc2 = new TableCell();
            tc2.Append(CreateParagraph("كشـف ", JustificationValues.Center));
            tc2.Append(CreateParagraph("أسماء السادة أعضاء لجنة سير الامتحان ", JustificationValues.Center, "", "12pt", true));

            var table2 = new Table();
            table2.AppendChild<TableProperties>(new TableProperties
            {
                TableWidth = new TableWidth() { Width = "90%", Type = TableWidthUnitValues.Auto },
                BiDiVisual = new BiDiVisual(),
                TablePositionProperties = new TablePositionProperties { TablePositionXAlignment = HorizontalAlignmentValues.Center }
            });
            var row1 = new TableRow();
            row1.Append(CreateTableCell("الدور", "", JustificationValues.Left, "50%", "", "10pt", true));
            row1.Append(CreateTableCell(data.Term, "", JustificationValues.Left, "50%", "", "10pt"));
            var row2 = new TableRow();
            row2.Append(CreateTableCell("أسم اللجنة", "", JustificationValues.Left, "50%", "", "10pt", true));
            row2.Append(CreateTableCell(data.Name, "", JustificationValues.Left, "50%", "", "10pt"));
            var row3 = new TableRow();
            row3.Append(CreateTableCell("مديرية / إدارة", "", JustificationValues.Left, "50%", "", "10pt", true));
            row3.Append(CreateTableCell(data.LearningManagement, "", JustificationValues.Left, "50%", "", "10pt"));
            var row4 = new TableRow();
            row4.Append(CreateTableCell("عنــوان اللجنة", "", JustificationValues.Left, "50%", "", "10pt", true));
            row4.Append(CreateTableCell(data.Address, "", JustificationValues.Left, "50%", "", "10pt"));

            table2.Append(row1);
            table2.Append(row2);
            table2.Append(row3);
            table2.Append(row4);

            tc2.Append(table2);
            tc2.Append(CreateParagraph(""));

            var tableWidth2 = new TableCellWidth
            {
                Type = TableWidthUnitValues.Auto,
                Width = "47%"
            };
            tc2.Append(new TableCellProperties(tableWidth2));
            //cell 3
            var tc3 = new TableCell();

            tc3.Append(CreateParagraph(" استمارة رقم  13 د ", JustificationValues.Right, "", "12pt"));
            var table3 = new Table();
            table3.AppendChild<TableProperties>(new TableProperties
            {
                TableWidth = new TableWidth() { Width = "90%", Type = TableWidthUnitValues.Auto },
                BiDiVisual = new BiDiVisual(),
                TablePositionProperties = new TablePositionProperties { TablePositionXAlignment = HorizontalAlignmentValues.Center }
            });

            var row5 = new TableRow();
            row5.Append(CreateTableCell("رقم اللجنة", "", JustificationValues.Left, "50%", "", "10pt", true));
            row5.Append(CreateTableCell(data.Number.ToString(), "", JustificationValues.Left, "50%", "", "10pt"));
            var row6 = new TableRow();
            row6.Append(CreateTableCell("نوع اللجنة", "", JustificationValues.Left, "50%", "", "10pt", true));
            row6.Append(CreateTableCell(data.CommitteType, "", JustificationValues.Left, "50%", "", "10pt"));
            var row7 = new TableRow();
            row7.Append(CreateTableCell("عدد الطلبة", "", JustificationValues.Left, "50%", "", "10pt", true));
            row7.Append(CreateTableCell(data.StudentCount.ToString(), "", JustificationValues.Left, "50%", "", "10pt"));
            table3.Append(row5);
            table3.Append(row6);
            table3.Append(row7);

            tc3.Append(table3);
            tc3.Append(CreateParagraph(""));

            var tableWidth3 = new TableCellWidth
            {
                Type = TableWidthUnitValues.Auto,
                Width = "25%"
            };
            tc3.Append(new TableCellProperties(tableWidth3));


            tr.Append(tc);
            tr.Append(tc2);
            tr.Append(tc3);
            table.Append(tr);

            header1.Append(table);

            headerPart1.Header = header1;



            SectionProperties sectionProperties1 = mainDocPart.Document.Body.Descendants<SectionProperties>().FirstOrDefault();
            if (sectionProperties1 == null)
            {
                sectionProperties1 = new SectionProperties() { };
                mainDocPart.Document.Body.Append(sectionProperties1);
            }
            HeaderReference headerReference1 = new HeaderReference() { Type = HeaderFooterValues.Default, Id = "r97" };


            sectionProperties1.InsertAt(headerReference1, 0);

        }

        private static void ApplyFooter(WordprocessingDocument doc)
        {
            // Get the main document part.
            MainDocumentPart mainDocPart = doc.MainDocumentPart;

            FooterPart footerPart1 = mainDocPart.AddNewPart<FooterPart>("r98");



            Footer footer1 = new Footer();

            Table table = new Table();

            TableProperties props = new TableProperties(
                new TableWidth() { Width = "100%", Type = TableWidthUnitValues.Auto });

            props.BiDiVisual = new BiDiVisual();

            table.AppendChild<TableProperties>(props);
            var tr = new TableRow();
            //cell 1
            var tc = new TableCell();
            tc.Append(CreateParagraph("أملاه:	"));
            tc.Append(CreateParagraph("كتبه :	"));
            var tableWidth = new TableCellWidth
            {
                Type = TableWidthUnitValues.Auto,
                Width = "50%"
            };
            tc.Append(new TableCellProperties(tableWidth));

            //cell 2
            var tc2 = new TableCell();
            tc2.Append(CreateParagraph(" راجع الأمـلاء  :  "));
            tc2.Append(CreateParagraph("راجع الكتابة   : "));
            tc2.Append(CreateParagraph("رئيس لجنة الإدارة         : "));

            var tableWidth2 = new TableCellWidth
            {
                Type = TableWidthUnitValues.Auto,
                Width = "50%"
            };
            tc2.Append(new TableCellProperties(tableWidth2));


            tr.Append(tc);
            tr.Append(tc2);
            table.Append(tr);

            footer1.Append(table);


            footerPart1.Footer = footer1;



            SectionProperties sectionProperties1 = mainDocPart.Document.Body.Descendants<SectionProperties>().FirstOrDefault();
            if (sectionProperties1 == null)
            {
                sectionProperties1 = new SectionProperties() { };
                mainDocPart.Document.Body.Append(sectionProperties1);
            }
            FooterReference footerReference1 = new FooterReference() { Type = DocumentFormat.OpenXml.Wordprocessing.HeaderFooterValues.Default, Id = "r98" };


            sectionProperties1.InsertAt(footerReference1, 0);

        }

        private static Paragraph CreateParagraph(string text, JustificationValues align = JustificationValues.Left, string font = "", string fontSize = "", bool isBold = false, bool isUnderlines = false)
        {
            Paragraph p = new Paragraph();

            Run r = new Run();

            RunProperties runProp = new RunProperties(); // Create run properties.
            RunFonts runFont = new RunFonts();           // Create font
            runFont.Ascii = string.IsNullOrWhiteSpace(font) ? "Arial" : font;
            runProp.Append(runFont);

            if (!string.IsNullOrWhiteSpace(fontSize))
            {
                FontSize size = new FontSize();
                size.Val = new StringValue(fontSize);  // 48 half-point font size
                runProp.Append(size);
            }

            if (isBold)
            {
                runProp.Append(new Bold());
            }
            if (isUnderlines)
            {
                runProp.Append(new Underline());
            }

            r.PrependChild<RunProperties>(runProp);

            Text t = new Text(text);

            //Append elements appropriately. 
            r.Append(t);

            p.Append(r);
            ParagraphProperties pp = p.ChildElements.First<ParagraphProperties>();

            var ppp = new ParagraphProperties { Justification = new Justification { Val = JustificationValues.Right } };
            if (pp == null)
            {
                pp = new ParagraphProperties();
                p.InsertBefore(pp, p.First());
            }

            pp.Append(new Justification() { Val = align });
            pp.Append(new BiDi());
            //pp.Append(new TextDirection { Val = TextDirectionValues.TopToBottomRightToLeft });

            return p;
        }

        private static TableCell CreateTableCell(string text, string backgroundColor = "", JustificationValues align = JustificationValues.Left, string width = "", string font = "", string fontSize = "", bool isBold = false, bool isUnderlines = false)
        {
            var cell = new TableCell();
            TableCellProperties tableCellProperties = new TableCellProperties()
            {
                TableCellVerticalAlignment = new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
            };
            if (!string.IsNullOrWhiteSpace(backgroundColor))
                tableCellProperties.Append(new Shading { Color = "auto", Fill = backgroundColor, Val = ShadingPatternValues.Clear });

            if (!string.IsNullOrWhiteSpace(width))
                tableCellProperties.Append(new TableCellWidth { Width = width });

            cell.Append(CreateParagraph(text, align, font, fontSize, isBold));
            cell.Append(tableCellProperties);

            return cell;

        }

    }
}