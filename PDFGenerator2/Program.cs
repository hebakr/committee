﻿using Committes.Repositories.Persistence;
using Committes.Repositories.Persistence.DbContexts;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFGenerator2
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDoc("../doc1.doc");
        }

        public static void CreateDoc(string docName)
        {
            // Create a Wordprocessing document. 
            using (WordprocessingDocument myDoc = WordprocessingDocument.Create(docName, WordprocessingDocumentType.Document))
            {
                // Add a new main document part. 
                MainDocumentPart mainPart = myDoc.AddMainDocumentPart();

                HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();
                FooterPart footerPart = mainPart.AddNewPart<FooterPart>();

              
                //Create DOM tree for simple document. 
                mainPart.Document = new Document();
                Body body = new Body();
                mainPart.Document.Append(body);

                //Add Table 

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


                headerRow.Append(CreateTableCell("م", bgColor,  JustificationValues.Center, "5%"));
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

                row2.Append(CreateTableCell("1", "", JustificationValues.Center));
                var c1 = CreateTableCell("رئيس اللجنة", bgColor, JustificationValues.Left, "", "Arial", "14pt", true, true);
                c1.Append(CreateParagraph("محمد"));
                row2.Append(c1);

                row2.Append(CreateTableCell("ابراهيم"));
                row2.Append(CreateTableCell("إستلام وإمتحان"));
                row2.Append(CreateTableCell("تقدير الدرجات"));
                table.Append(row2);

                var row3 = new TableRow();

                row3.Append(CreateTableCell("1", "", JustificationValues.Center));
                var c2 = CreateTableCell("المراقب الأول", bgColor, JustificationValues.Left, "", "Arial", "14pt", true, true);
                c2.Append(CreateParagraph(""));
                row3.Append(c2);
                row3.Append(CreateTableCell(""));
                row3.Append(CreateTableCell("إستلام وإمتحان"));
                row3.Append(CreateTableCell("تقدير الدرجات"));
                table.Append(row3);

                for (var i = 0; i < 80; i++)
                {
                    var tr = new TableRow();
                    for (var j = 0; j < 5; j++)
                    {
                        var tc = new TableCell();

                        //tc.Append(new Paragraph(new Run(new Text(string.Format("cell {0}, {1}", i, j)))));
                        tc.Append(CreateParagraph($"{i}, {j}", JustificationValues.Center));
                        // Assume you want columns that are automatically sized.
                        tc.Append(new TableCellProperties(
                            new TableCellWidth { Type = TableWidthUnitValues.Auto }
                            , new TableCellMargin {
                                StartMargin = new StartMargin { Width = "10pt" }
                            }));

                        tr.Append(tc);
                    }
                    table.Append(tr);
                }

                var row = table.GetFirstChild<TableRow>();

                

                mainPart.Document.Append(table); 

                ApplyHeader(myDoc);
                ApplyFooter(myDoc);
                // Save changes to the main document part. 
                mainPart.Document.Save();
            }
        }

        public static void ApplyHeader(WordprocessingDocument doc)
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
            tc.Append(CreateParagraph("وزارة التربية و التعليم والتعليم الفني  الادارة العامة للامتحانات", JustificationValues.Center));
            tc.Append(CreateParagraph("لجنة الإدارة لامتحان  دبلوم  المدارس الثانوية الصناعية نظام السنوات الثلاث قطاع القاهرة", JustificationValues.Center));
            var tableWidth = new TableCellWidth
            {
                Type = TableWidthUnitValues.Auto,
                Width = "28%"
            };
            tc.Append(new TableCellProperties(tableWidth));

            //cell 2
            var tc2 = new TableCell();
            tc2.Append(CreateParagraph("كشـف ", JustificationValues.Center));
            tc2.Append(CreateParagraph("أسماء السادة أعضاء لجنة سير الامتحان ", JustificationValues.Center, "", "26", true));

            var tableWidth2 = new TableCellWidth
            {
                Type = TableWidthUnitValues.Auto,
                Width = "47%"
            };
            tc2.Append(new TableCellProperties(tableWidth2));
            //cell 3
            var tc3 = new TableCell();

            tc3.Append(CreateParagraph(" استمارة رقم  13 د ", JustificationValues.Right));
            tc3.Append(CreateParagraph("رقم اللجنة: " + 25, JustificationValues.Left));
            tc3.Append(CreateParagraph("نوع اللجنة:  صناعي ", JustificationValues.Left));
            tc3.Append(CreateParagraph("عدد الطلبة: " + 98, JustificationValues.Left));

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

        public static void ApplyFooter(WordprocessingDocument doc)
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


            if (pp == null)
            {
                pp = new ParagraphProperties();
                p.InsertBefore(pp, p.First());
            }

            pp.Append(new Justification() { Val = align });
            pp.Append(new BiDi());

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
