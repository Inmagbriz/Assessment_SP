Feature: SpanishPointWeb

Background:
	Given the user has navigated to 'https://www.spanishpoint.ie/'


Scenario: Displayed panel header is Employee Experience and displayed paragraph starts with Engaging, Mobile Intranet and Digital Workspace collaboration solution in Employee Experience panel
	Given the user expands 'Solutions & Services' option in top menu
	And the user selects 'Modern Work' option in the menu displayed
	When the user selects 'Employee Experience' under the 'Modern Workplace Solutions' section
	Then the displayed panel has the a header with the text 'Employee Experience'
	And the displayed paragraph starts with the text 'Engaging, Mobile Intranet and Digital Workspace collaboration solution'